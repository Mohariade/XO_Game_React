using Business_And_Data_Layers.Data;
using Business_And_Data_Layers.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () => { return "Is Development"; });
}
else
{
    app.MapGet("/", () => { return "Docuemtation : houdaifabouamine-001-site1.gtempurl.com/swagger"; });
}

app.MapGet("/Games/Join", () =>
{
    
    DataLayer database = new DataLayer();
    List<Game> list = database.Games.Where(g => g.Status == Game.enStatus.Waiting_For_Player_2).ToList();

    Game? game = null;

    if (list.Count > 0)
    {
        game = list[0];
    }

    if (game != null)
    {
        game.Status = Game.enStatus.Ongoing;
        database.Games.Update(game);
        database.SaveChanges();
        return new { game, player = game.Player2_Id };
    }
    else
    {

        Guid player1 = Guid.NewGuid();
        Guid player2 = Guid.NewGuid();

        game = Game.Create(player1, player2);

        database.Games.Add(game);
        database.SaveChanges();

        return new { game, player = player1 };
    }
}
);

app.MapPut("/Games/{Game_Id}/{Player_Id}", (Guid Game_Id,Guid Player_Id, [FromBody] Game game) =>
{

    if (!game.isRunning()) return game;

    if (Player_Id != game.PlayerTurn_Id) return game;

    if(game.PlayerTurn_Id == game.Player1_Id)
    {
        game.PlayerTurn_Id = game.Player2_Id;
    }
    else
    {
        game.PlayerTurn_Id = game.Player1_Id;
    }

    return game;
}
);

if (app.Environment.IsDevelopment())
{
    app.Run("https://localhost:3000/");
}
else
{
    app.Run();
}