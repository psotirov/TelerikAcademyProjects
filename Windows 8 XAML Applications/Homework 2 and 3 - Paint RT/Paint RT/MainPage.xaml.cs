using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Storage;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Paint_RT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private RotateTransform rotateColors = new RotateTransform() { CenterX = 150, CenterY = 150, Angle = 0 };
        private PointerPoint figureStartPoint;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Figures_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var margin = Figures.Margin;

            if (e.Cumulative.Translation.X > 0)
            {
                margin.Left += 70;
                if (margin.Left > 150)
                {
                    margin.Left = 10;
                }
            }
            else
            {
                margin.Left -= 70;
                if (margin.Left < 10)
                {
                    margin.Left = 150;
                }
            }

            Figures.Margin = margin;
        }

        private void Colors_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var angle = rotateColors.Angle;
            angle += (e.Cumulative.Rotation > 0) ? 90 : 270;
            angle = angle % 360;
            rotateColors.Angle = angle;
            Colors.RenderTransform = rotateColors;
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            figureStartPoint = e.GetCurrentPoint(Canvas);
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (figureStartPoint != null)
            {
                var index = (int)((Figures.Margin.Left - 10) / 70);
                Figure figure = new Figure();
                figure.X1 = figureStartPoint.Position.X;
                figure.Y1 = figureStartPoint.Position.Y;
                figure.X2 = e.GetCurrentPoint(Canvas).Position.X;
                figure.Y2 = e.GetCurrentPoint(Canvas).Position.Y;

                figure.Fig = (FigureType)index;

                switch ((int)rotateColors.Angle)
                {
                    case 0:
                        figure.Color = Windows.UI.Color.FromArgb(255, 255, 0, 0);
                        break;
                    case 90:
                        figure.Color = Windows.UI.Color.FromArgb(255, 0, 255, 0);
                        break;
                    case 180:
                        figure.Color = Windows.UI.Color.FromArgb(255, 0, 0, 255);
                        break;
                    case 270:
                        figure.Color = Windows.UI.Color.FromArgb(255, 0, 0, 0);
                        break;
                    default:
                        break;
                }

                AddFigureToCanvas(figure);
                figureStartPoint = null;
            }
        }

        private async void ButtonClickOpenFile(object sender, RoutedEventArgs e)
        {
            var canvasContent = "";

            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.FileTypeFilter.Add(".paint");
            var readFile = await openPicker.PickSingleFileAsync();
            try
            {
                canvasContent = await Windows.Storage.FileIO.ReadTextAsync(readFile);
            }
            catch (Exception)
            {
                new Windows.UI.Popups.MessageDialog("Could not read the selected file").ShowAsync();
            }

            DeserializeCanvas(canvasContent);
        }

        private async void ButtonClickSaveFile(object sender, RoutedEventArgs e)
        {
            var canvasContent = SerializeCanvas();

            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.FileTypeChoices.Add(
                new KeyValuePair<string, IList<string>>("Painter File Format", new string[] { ".paint" })
                );

            var saveFile = await savePicker.PickSaveFileAsync();

            if (saveFile != null)
            {
                try
                {
                    await Windows.Storage.FileIO.WriteTextAsync(saveFile, canvasContent);
                }
                catch (Exception)
                {
                    new Windows.UI.Popups.MessageDialog("Could not write the selected file").ShowAsync();
                }
            }
        }

        private string SerializeCanvas()
        {
            var shapes = new List<Figure>();

            foreach (var item in Canvas.Children)
            {
                var shape = item as Shape;
                if (shape != null)
                {
                    var newShape = new Figure();
                    var line = shape as Line;
                    if (line != null)
                    {
                        newShape.Fig = FigureType.Line;
                        newShape.X1 = line.X1;
                        newShape.Y1 = line.Y1;
                        newShape.X2 = line.X2;
                        newShape.Y2 = line.Y2;
                    }
                    else
                    {
                        newShape.Fig = ((shape as Rectangle) != null) ? FigureType.Rectangle : FigureType.Ellipse;
                        newShape.X1 = Windows.UI.Xaml.Controls.Canvas.GetTop(shape);
                        newShape.Y1 = Windows.UI.Xaml.Controls.Canvas.GetLeft(shape);
                        newShape.X2 = newShape.X1 + shape.Width;
                        newShape.Y2 = newShape.Y1 + shape.Height;                        
                    }

                    newShape.Color = (shape.Fill as SolidColorBrush).Color;
                    shapes.Add(newShape);
                }
            }

            var result = JsonConvert.SerializeObject(shapes);
            return result;
        }

        private void DeserializeCanvas(string data)
        {
            Canvas.Children.Clear();
            var shapes = JsonConvert.DeserializeObject<List<Figure>>(data);
            foreach (var item in shapes)
            {
                AddFigureToCanvas(item);
            }
        }

        private void AddFigureToCanvas(Figure singleFigure)
        {
            Shape figure = null;
            if (singleFigure.Fig == FigureType.Line) // line
            {
                figure = new Line();
                (figure as Line).X1 = singleFigure.X1;
                (figure as Line).Y1 = singleFigure.Y1;
                (figure as Line).X2 = singleFigure.X2;
                (figure as Line).Y2 = singleFigure.Y2;
            }
            else
            {
                if (singleFigure.Fig == FigureType.Ellipse) // ellipse
                {
                    figure = new Ellipse();
                }
                else if (singleFigure.Fig == FigureType.Rectangle) // rectangle
                {
                    figure = new Rectangle();
                }
                else
                {
                    return;
                }

                figure.Height = Math.Abs(singleFigure.Y2 - singleFigure.Y1);
                figure.Width = Math.Abs(singleFigure.X2 - singleFigure.X1);
                Windows.UI.Xaml.Controls.Canvas.SetTop(figure, Math.Min(singleFigure.Y1, singleFigure.Y2));
                Windows.UI.Xaml.Controls.Canvas.SetLeft(figure,Math.Min(singleFigure.X1, singleFigure.X2));
            }

            figure.StrokeThickness = 10;
            figure.Fill = new SolidColorBrush(singleFigure.Color);
            figure.Stroke = figure.Fill;
            Canvas.Children.Add(figure);
        }
    }
}
