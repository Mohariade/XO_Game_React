using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_And_Data_Layers.Models
{
    public class Game
    {
        [Key]
        [Column("Game_Id")]
        public Guid Id { get; set; }

        [Column("Player1_Id")]
        public Guid Player1_Id { get; set; }

        [Column("Player2_Id")]
        public Guid Player2_Id { get; set; }

        [Column("PlayerTurn_Id")]
        public Guid PlayerTurn_Id { get; set; }

        public enStatus Status { get; set; }
        public enum enStatus { Waiting_For_Player_2,Ongoing, Player_1_Win, Player_2_Win, Draw }

        [MaxLength(9)]
        [MinLength(9)]
        public string Board { get; set; } = "/////////";

        public Game() { }

        static public Game Create(Guid player1,Guid player2) 
        {
            Game game = new Game()
            {
                Id = Guid.NewGuid(),
                Player1_Id = player1,
                Player2_Id = player2,
                PlayerTurn_Id = (new Random().Next() % 2 == 0) ? player1 : player2,
                Status = enStatus.Waiting_For_Player_2
            };

            return game;
        }

        static public Game Load(Guid id, Guid player_1, Guid player_2, Guid player_Turn, enStatus status, string board)
        {
            return new Game()
            {
                Id = id,
                Player1_Id = player_1,
                Player2_Id = player_2,
                PlayerTurn_Id = player_Turn,
                Status = status,
                Board = board
            };
        }

        public bool isRunning()
        {
            return Status == enStatus.Waiting_For_Player_2 || Status == enStatus.Ongoing;
        }
    }
}
