using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace Practice.ViewModels.Living
{
    public class LivingFormViewModel
    {
        public ICollection<Feedback> Feedbacks { get; set; }
        public List<string> ImageList { get; set; }

        public string Name { get; set; }
        public string Feedback { get; set; }
        private Random random;
        private void InitializeImage()
        {
            ImageList = new List<string>();

            ImageList.Add("/Content/img/nan.jpg");
            ImageList.Add("/Content/img/tom.jpg");
            ImageList.Add("/Content/img/joe.jpg");
            ImageList.Add("/Content/img/matt.jpg");
            ImageList.Add("/Content/img/stevie.jpg");
            ImageList.Add("/Content/img/steve.jpg");
            ImageList.Add("/Content/img/christian.jpg");

        }
        public LivingFormViewModel()
        {
            random = new Random();
            InitializeImage();
        }

        public string GetRandomImage()
        {
            var index = random.Next(0, ImageList.Count);
            var photo = ImageList[index];
            ImageList.Remove(photo);
            return photo;
        }
    }
}