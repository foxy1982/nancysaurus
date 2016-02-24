using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;
using NancySaurus.Models;

namespace NancySaurus.Modules
{
    public class DinosaurModule : NancyModule
    {
        private static readonly List<Dinosaur> Dinosaurs = new List<Dinosaur>
        {
            new Dinosaur
            {
                Name = "Kierkegaard",
                HeightInFeet = 6,
                Status = "Inflated"
            }
        };

        public DinosaurModule()
        {
            Get["/dinosaurs/{id}"] = parameters => Dinosaurs[parameters.id - 1];
            Post["/dinosaurs"] = parameters =>
            {
                var model = this.Bind<Dinosaur>();
                Dinosaurs.Add(model);
                return Dinosaurs.Count.ToString();
            };
        }
    }
}