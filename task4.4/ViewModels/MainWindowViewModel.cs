using System.Collections.Generic;
using System;


namespace task4._4.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        BlogEntities =
        [
            new BlogEntity { Article = "Article 1", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc at libero in risus ultrices faucibus sed vitae est. Pellentesque in orci hendrerit, lacinia odio et, pellentesque mauris. Nullam consectetur lacinia commodo. Cras ullamcorper urna facilisis sapien finibus sollicitudin. Aliquam bibendum fringilla nunc vel efficitur. Vestibulum interdum elit tellus, sed fringilla quam ultrices in. Cras non mi molestie, porta ante at, condimentum purus.\r\n\t\t\t\tSed ut eros a leo tincidunt porttitor. Maecenas consequat eget massa et tempus. Curabitur ultricies consequat risus quis viverra. Donec in neque ligula. Nunc imperdiet, velit non euismod interdum, quam libero maximus mi, ac bibendum orci libero ut erat. Phasellus tincidunt maximus dui at malesuada. Sed vitae urna at orci malesuada congue vitae sit amet purus. Aliquam nisi nibh, ornare ultrices sagittis vel, pellentesque ac lorem. Duis posuere dictum elit, a mollis metus eleifend vitae. Nam suscipit arcu non tincidunt sodales. Aliquam vitae urna nec velit consequat dignissim. Nullam tristique arcu vel dictum laoreet. Sed fringilla est magna, sed malesuada diam tincidunt ut.\r\n\t\t\t\tDonec congue est quam, nec efficitur lorem mattis varius. Proin feugiat elit ut quam sagittis, ac volutpat erat aliquam. Vestibulum ultricies erat ut elit rutrum, id lobortis urna vehicula. Maecenas euismod ornare ante eget imperdiet. Nunc placerat pretium ultricies. Maecenas vehicula, massa ut aliquam facilisis, orci sapien pharetra nisi, quis dapibus quam sem in odio. Suspendisse placerat tortor id convallis congue. Curabitur dapibus finibus leo, at suscipit arcu porta sit amet. Sed facilisis neque a mi maximus efficitur.\r\n\t\t\t\tPraesent sed sapien felis. Vivamus et tellus nibh. Ut vestibulum nulla sed dolor egestas venenatis. Proin vestibulum blandit iaculis.\r\n\t\t\t", TagsList = ["Tag1, Tag2"], ImagePath = "petya.jpg" }
        ];
        NewsEntities =
        [
            new NewsEntity { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc at libero in risus ultrices faucibus sed vitae est. Pellentesque in orci hendrerit, lacinia odio et, pellentesque mauris. Nullam consectetur lacinia commodo. Cras ullamcorper urna facilisis sapien finibus sollicitudin. Aliquam bibendum fringilla nunc vel efficitur...", PublishDate = DateTime.Now },
            new NewsEntity { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc at libero in risus ultrices faucibus sed vitae est. Pellentesque in orci hendrerit, lacinia odio et, pellentesque mauris. Nullam consectetur lacinia commodo. Cras ullamcorper urna facilisis sapien finibus sollicitudin. Aliquam bibendum fringilla nunc vel efficitur...", PublishDate = DateTime.Now },
        ];
    }
    public List<BlogEntity> BlogEntities { get; set; }

    public List<NewsEntity> NewsEntities { get; set; }

}
