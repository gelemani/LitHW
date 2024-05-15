using System.Collections.Generic;
using System;
using task4._4.Models;

namespace task4._4.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        BlogEntities = new List<BlogEntity>()
        {
            new BlogEntity()
            {
                Article = "Коротко о главном",
                Text = "Were dinosaurs warm-blooded like birds and mammals or cold-blooded like reptiles? It’s one of paleontology’s oldest questions, and gleaning the answer matters because it illuminates how the prehistoric creatures may have lived and behaved.\r\n\r\nChallenging the prevailing idea that they were all slow, lumbering lizards that basked in the sun to regulate their body temperature, research over the past three decades has revealed that some dinosaurs were likely birdlike, with feathers and perhaps the ability to generate their own body heat.\r\n\r\nHowever, it’s hard to find evidence that unquestionably shows what dinosaur metabolisms were like. Clues from dinosaur eggshells and bones have suggested that some dinosaurs were warm-blooded and others were not.\r\n\r\nA new study published in the journal Current Biology on Wednesday suggested that three main dinosaur groups adapted differently to changes in temperature, with the ability to regulate body temperature evolving in the early Jurassic Period about 180 million years ago.",
                ImagePath = "petya.jpg",
                Tags = new List<string> {"Tag1", "Tag2", "Tag3", "Tag 4"}
            }
        };
        NewsEntities = new List<NewsEntity>
        {
            new() { Text = "Запасы нефти в США за неделю снизились на 2,5 млн баррелей", PublishTime = DateTime.Now },
            new() { Text = "ФРС оставила ключевую ставку без изменений", PublishTime = DateTime.Now.AddDays(-3) },
            new() { Text = "РФ опустилась на восьмое место по объему валютных резервов", PublishTime = DateTime.Now.AddDays(-10) }
        };
    }
    public List<BlogEntity> BlogEntities { get; set; }
    public List<NewsEntity> NewsEntities { get; set; }

}
