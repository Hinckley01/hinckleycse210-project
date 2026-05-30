class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("10 Tips for Better Coding", "TechWithTim", 620);
        video1.AddComment(new Comment("Alice Johnson", "This was super helpful, thank you!"));
        video1.AddComment(new Comment("Bob Smith", "Tip #7 really changed how I write loops."));
        video1.AddComment(new Comment("Carol White", "Can you make a follow-up on clean architecture?"));
        video1.AddComment(new Comment("David Lee", "Best coding video I've seen this year!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How to Make Homemade Pizza", "ChefMike", 845);
        video2.AddComment(new Comment("Emma Davis", "I tried this recipe and it was amazing!"));
        video2.AddComment(new Comment("Frank Moore", "What temperature should the oven be?"));
        video2.AddComment(new Comment("Grace Hall", "Finally a recipe that actually works!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Beginner's Guide to Investing", "MoneyMatters", 1380);
        video3.AddComment(new Comment("Henry Wilson", "This should be taught in schools."));
        video3.AddComment(new Comment("Isabella Clark", "Great breakdown of index funds!"));
        video3.AddComment(new Comment("James Lewis", "Very clear explanation, subscribed!"));
        video3.AddComment(new Comment("Karen Young", "Can you cover crypto investing next?"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Morning Yoga for Beginners", "YogaWithSarah", 1140);
        video4.AddComment(new Comment("Liam Martinez", "My back feels so much better after this."));
        video4.AddComment(new Comment("Mia Thompson", "Perfect way to start the day!"));
        video4.AddComment(new Comment("Noah Garcia", "How many times a week should I do this?"));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"Title:    {video.GetTitle()}");
            Console.WriteLine($"Author:   {video.GetAuthor()}");
            Console.WriteLine($"Length:   {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("--- Comments ---");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
