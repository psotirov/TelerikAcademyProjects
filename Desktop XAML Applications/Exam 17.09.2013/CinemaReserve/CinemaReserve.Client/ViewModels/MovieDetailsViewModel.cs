using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReserve.Client.ViewModels
{
    public class MovieDetailsViewModel
    {
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public List<ProjectionTempModel> Projections { get; set; }

        public MovieDetailsViewModel()
        {
            this.Actors = new List<string>();
            this.Projections = new List<ProjectionTempModel>();
        }
    }

    public class ProjectionTempModel
    {
        public int Id { get; set; }

        public string Time { get; set; }

        public MovieModel Movie { get; set; }

        public CinemaModel Cinema { get; set; }

        public ProjectionTempModel()
        {
            this.Movie = new MovieModel();
            this.Cinema = new CinemaModel();
        }
    }
}
