using System;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }
    

    public void Run()
    {
        string input;

        while ((input = reader.ReadLine()) != "Enough! Pull back!")
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
                //result.AppendLine(arg.Message);
            }
        }

        this.writer.WriteLine(gameController.RequestResult());

        //gameController.RequestResult(result);
        //ConsoleWriter.WriteLine(result.ToString());
    }
}
