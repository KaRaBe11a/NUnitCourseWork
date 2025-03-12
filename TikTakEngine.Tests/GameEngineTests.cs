namespace TikTakEngine.Tests;

using Newtonsoft.Json.Bson;
using NUnit.Framework;

[TestFixture]
public class Test
{
    private GameEngine game;

    [SetUp]
    public void Setup()
    {
        game = new GameEngine();
    }

    [Test]
    public void TestInitialPlayer()
    {
        Assert.AreEqual('X', game.CurrentPlayer);
    }

    [Test]
    public void TestSwitchPlayer()
    {
        game.SwitchPlayer();
        Assert.AreEqual('O', game.CurrentPlayer);
        game.SwitchPlayer();
        Assert.AreEqual('X', game.CurrentPlayer);
    }

    [Test]
    public void TestMakeValidMove()
    {
        Assert.IsTrue(game.MakeMove(0, 0));
        Assert.AreEqual('O', game.CurrentPlayer);
    }

    [Test]
    public void TestMakeInvalidMove()
    {
        game.MakeMove(0, 0);
        Assert.IsFalse(game.MakeMove(0, 0));
    }

    [Test]
    public void TestVerticalWin()
    {
        for (int i = 0; i < 5; i++)
        {
            game.MakeMove(i, 0);
            game.SwitchPlayer();
        }
        game.SwitchPlayer();
        Assert.IsTrue(game.CheckWin());
    }

    [Test]
    public void TestDiagonalWin()
    {
        for (int i = 0; i< 5; i++)
        {
            game.MakeMove(i, i);
            game.SwitchPlayer();
        }
        game.SwitchPlayer();
        Assert.IsTrue(game.CheckWin());
    }

    [Test]
    public void TestDraw()
    {
        for (int i = 0; i<10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                game.MakeMove(i, j);
                game.SwitchPlayer();
            }
        }
        Assert.IsTrue(game.IsDraw());
    }
}