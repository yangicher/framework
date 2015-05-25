using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame.pingpong
{
    public class PingPongCore
    {
        public void Start()
        {
            Console.SetWindowSize(GameStatics.GameWidth, GameStatics.GameHeight);
            Console.CursorVisible = false;

            Actor field = new Actor();
            field.LocalPosition = new Vector3(0, 0, 0);
            field.AddComponent(new GameField(ConsoleColor.Red));

            Actor pads = new Actor();
            pads.Name = "Pad";
            pads.LocalPosition = new Vector3(2, 8, 0);

            PlayerPad playerPad = new PlayerPad('#', 5, ConsoleColor.Blue, ConsoleColor.Red);
            pads.AddComponent(playerPad);

            Actor ball = new Actor();
            ball.Name = "Ball";
            ball.LocalPosition = new Vector3(GameStatics.GameWidth / 2, GameStatics.GameHeight / 2, 0);

            Ball ballComponent = new Ball('%', ConsoleColor.White);
            ballComponent.Speed = 10f;
            ballComponent.Direction = new Vector3(-1, 1, 0).Normalized;
            ball.AddComponent(ballComponent);
            
            Scene scene = new Scene(GameStatics.GameWidth, GameStatics.GameHeight);
            scene.AddActor(field);
            scene.AddActor(pads);
            scene.AddActor(ball);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
