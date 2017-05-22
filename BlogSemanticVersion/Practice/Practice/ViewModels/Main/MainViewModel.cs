using DataAccessLayer.Entities;
using DataAccessLayer.Repository.QuizRepository;
using System.Collections.Generic;

namespace Practice.ViewModels.Main
{
    public class MainViewModel
    {
        private readonly QuizReadRepository quizReadRepository = new QuizReadRepository();
        public List<Article> Articles { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Quiz> Quizes { get; set; }

        public string SearchTag { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string[] SetTags { get; set; } = new string[10];

        public string ReadyTag
        {
            get
            {
                var tags = "";
                foreach (var item in SetTags)
                {
                    tags += '#' + item;
                }
                return tags;
            }
        }

        public double GetPerсent(int id)
        {
            return (int)quizReadRepository.GetPercent(id);
        }

        public int GetCountVote()
        {
            return quizReadRepository.GetCountVote();
        }
    }
}