Queue<string> SongsToPlay = new Queue<string>();
SongsToPlay.Enqueue("Viva la vida - Coldplay");
SongsToPlay.Enqueue("lovesong - adele");
SongsToPlay.Enqueue("one dance - Drake");
SongsToPlay.Enqueue("Shape of you - Ed Sheeran");

while (SongsToPlay.Count > 0)
{
    string song = SongsToPlay.Dequeue();
    Console.WriteLine($"Playing song: {song}");
}