using System;
using System.Linq;
using TicTacToe.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TicTacToe.Common
{
    public class MoveDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate XMoveTemplate { get; set; }
        public DataTemplate OMoveTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            MoveBase move = (MoveBase)item;
            DataTemplate dt = (move is XMove) ? this.XMoveTemplate : this.OMoveTemplate;
            return dt;
        }
    }
}
