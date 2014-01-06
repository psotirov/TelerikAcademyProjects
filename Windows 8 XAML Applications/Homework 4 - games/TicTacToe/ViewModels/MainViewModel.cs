using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using TicTacToe.Commands;
using System.Collections.ObjectModel;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.moves = new ObservableCollection<MoveBase>()
            {
                // Just some test values for the board
                new XMove() { Row = 0, Column = 0 },
                new OMove() { Row = 1, Column = 0 },
                new XMove() { Row = 1, Column = 1 },
                new OMove() { Row = 0, Column = 2 },
                new XMove() { Row = 2, Column = 2 }
            };
        }

        private ObservableCollection<MoveBase> moves;
        public IEnumerable<MoveBase> Moves
        {
            get
            {
                if (this.moves == null)
                {
                    this.moves = new ObservableCollection<MoveBase>();
                }

                return this.moves;
            }
            set
            {
                if (this.moves == null)
                {
                    this.moves = new ObservableCollection<MoveBase>();
                }

                this.moves.Clear();

                foreach (var move in value)
                {
                    this.moves.Add(move);
                }

                OnPropertyChanged("Moves");
            }
        }

    }
}
