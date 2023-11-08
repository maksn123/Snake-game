using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snake
{
    public partial class Form1 : Form
    {
        private int rI, rJ;//fruit cordinate 
        private PictureBox fruit;//picture box for fruit
        private PictureBox[] snake = new PictureBox[400];//array for snake  

        bool pause = false;
        //private Button btnp ;//pause/resume btn
        private Label labelScore;//label for earned points 
        private Label labelHighScore;//label for high score

        private int dirX, dirY;//move by X,Y
        private int _width = 600;//form width 
        private int _height = 480;//form height
        private int _sizeOfSides = 40;
        private int score=0;
        private ComboBox diff;
        public Form1()
        {
            InitializeComponent();

            //Form settings 
            this.Text = "Snake";
            this.Width = _width+20;
            this.Height = 600;
            dirX = 1;
            dirY = 0;

            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(530, 80);
            this.Controls.Add(labelScore);//додавання label для виводу очок

            labelHighScore = new Label();
            labelHighScore.Text = "High score: 0";
            labelHighScore.Location = new Point(530, 40);
            labelHighScore.AutoSize = true;
            this.Controls.Add(labelHighScore);


            snake[0] = new PictureBox();
            snake[0].Location = new Point(201, 201);
            snake[0].Size = new Size(_sizeOfSides-1, _sizeOfSides-1);
            snake[0].BackColor = Color.Red;
            this.Controls.Add(snake[0]);//Додавання змійки


            LoadHighScore();
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(_sizeOfSides, _sizeOfSides);
            _generateMap();
            _generateFruit();
            timer.Tick += new EventHandler(_update);
            timer.Interval = 200;
            //timer.Start();
            
            this.KeyDown += new KeyEventHandler(OKP);
        }

        private void _generateFruit()
        {
            //Fruit generathion
            Random r = new Random();
            bool isFruitOnSnake;
            do
            {
                isFruitOnSnake = false;
                // Generate a fruit location
                rI = r.Next(40, _height - _sizeOfSides);
                rJ = r.Next(40, _height - _sizeOfSides);

                // Adjust to the grid
                rI = rI - rI % _sizeOfSides + 1;
                rJ = rJ - rJ % _sizeOfSides + 1;

                // Check if the fruit is on the snake
                foreach (PictureBox snakePart in snake)
                {
                    if (snakePart != null && snakePart.Location == new Point(rI, rJ))
                    {
                        isFruitOnSnake = true;
                        break;
                    }
                }
            } while (isFruitOnSnake);  // Repeat if fruit is on the snake

            // Place the fruit
            fruit.Location = new Point(rI, rJ);
            this.Controls.Add(fruit);
        }

        private void _checkBorders()
        {
            //snake crush in border

            if (snake[0].Location.X < 40)//Left border
            {
                for(int _i = 0; _i <= score; _i++)
                {
                    _endGame();
                    this.Controls.Remove(snake[_i]);   
                    _initializeSnake();
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = 1;
            }
            if (snake[0].Location.X > _height+40)//right border
            {
                for (int _i = 0; _i <= score; _i++)
                {
                    _endGame();
                    this.Controls.Remove(snake[_i]);
                    _initializeSnake();
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = -1;
            }
            if (snake[0].Location.Y < 40)//Low border
            {
                for (int _i = 0; _i <= score; _i++)
                {
                    _endGame();
                    this.Controls.Remove(snake[_i]);
                    _initializeSnake();
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = 1;
            }

            if (snake[0].Location.Y > _height+40)//high border
            {
                for (int _i = 0; _i <= score; _i++)
                {
                    _endGame();
                    this.Controls.Remove(snake[_i]);
                    _initializeSnake();
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                
                dirY = -1;
            }
        }

        private void _eatItself()
        {
            
            for (int i = 1; i < score; i++)
            {
                if (snake[0].Bounds.IntersectsWith(snake[i].Bounds))
                {
                    _endGame();
                    break; // Exit the loop since the game is over
                }
            }


        }

        private void _endGame()
        {
            timer.Stop();
            MessageBox.Show("Game over! Your score was: " + score, "Snake", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Code to reset the game, or you can close the form, etc.
            
            UpdateHighScore(score);
            _resetGame();
        }

        private void _resetGame()
        {
            // Reset snake positions, score, and other game states as needed
            // This will depend on how you've structured the rest of your code
            for (int i = score; i >= 0; i--)
            {
                this.Controls.Remove(snake[i]);
                snake[i] = null;
            }
            score = 0;
            labelScore.Text = "Score: " + score;
            // Reset snake head position, direction, etc.
            // Reinitialize the snake and start the timer again
            _initializeSnake();
            _generateFruit();
            timer.Start();
        }
        private void _initializeSnake()
        {
            snake[0] = new PictureBox();
            snake[0].Location = new Point(201, 201); // Set to starting position
            snake[0].Size = new Size(_sizeOfSides - 1, _sizeOfSides - 1);
            snake[0].BackColor = Color.Red;
            this.Controls.Add(snake[0]);
            LoadHighScore();
            // Set the initial direction or other initialization code here
        }

        private void _eatFruit()
        {
            //snake eat fruit
            if(snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                labelScore.Text = "Score: " + ++score;//score++ 
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 40 * dirX, snake[score - 1].Location.Y - 40 * dirY);
                snake[score].Size = new Size(_sizeOfSides-1, _sizeOfSides-1);
                snake[score].BackColor = Color.Red;
                this.Controls.Add(snake[score]);
                _generateFruit();
            }
        }
        
       

        private void _generateMap()
        {
            //Generate gorisontal lines 
            for (int i = 0; i < (_width-40) / _sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(40, _sizeOfSides * i);
                pic.Size = new Size(_width - 120, 1);
                this.Controls.Add(pic);
            }
            //Generate vertical lines 
            for (int i = 0; i <= _height  / _sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(40+ _sizeOfSides * i,40);
                pic.Size = new Size(1,_width -120);
                this.Controls.Add(pic);
            }
        }

        private void _moveSnake()
        {
            //Snake move logic
            for(int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            } 
            snake[0].Location = new Point(snake[0].Location.X + dirX * (_sizeOfSides ) ,snake[0].Location.Y + dirY * (_sizeOfSides ));
        }

        private void легкоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 300;
            важкоToolStripMenuItem.Checked = false;
            легкоToolStripMenuItem.Checked = true;
            середнєToolStripMenuItem.Checked = false;
        }

        private void новаГраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Змійка з'їла себе 
            for (int _i = 1; _i < score; _i++)
            {
                
                    for (int _j = _i; _j <= score; _j++)
                        this.Controls.Remove(snake[_j]);
                    score = score - (score - _i + 1);
                    labelScore.Text = "Score: " + score;//Очки рівні нулю 
                
            }
        }

       
        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pause ==false)
            {
                timer.Stop();
                паузаToolStripMenuItem.Checked=true;
                pause = true;
            }
            else if (pause == true)
            {
                timer.Start();
                паузаToolStripMenuItem.Checked = false;
                pause = false;
            }
        }

        private void середнєToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 200;
            важкоToolStripMenuItem.Checked = false;
            легкоToolStripMenuItem.Checked = true;
            середнєToolStripMenuItem.Checked = false;
        }

        private void важкоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 100;
            важкоToolStripMenuItem.Checked = true;
            легкоToolStripMenuItem.Checked = false;
            середнєToolStripMenuItem.Checked = false;   
        }
        private void SaveHighScore(int highScore)
        {
            string filePath = "highscore.txt"; // You can choose a different path or filename

            try
            {
                File.WriteAllText(filePath, highScore.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving high score: " + ex.Message);
            }
        }
        private int LoadHighScore()
        {
            string filePath = "highscore.txt";

            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "0");
                    labelHighScore.Text = "High Score: 0";
                    return 0;
                }
                else
                {
                    string highScoreString = File.ReadAllText(filePath);
                    int highScore = int.TryParse(highScoreString, out highScore) ? highScore : 0;
                    labelHighScore.Text = "High Score: " + highScore;
                    return highScore;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading high score: " + ex.Message);
            }

            return 0;
        }
        private void UpdateHighScore(int score)
        {
            int highScore = LoadHighScore();

            if (score > highScore)
            {
                SaveHighScore(score);
                labelHighScore.Text = "High Score: " + score;
                MessageBox.Show("New high score: " + score);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gameRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void _update(Object myObject,EventArgs eventsArgs)
        {
            
                _checkBorders();
                _eatFruit();
                _moveSnake();
                _eatItself();
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            //Керування змійкою за допомогою клавіш 
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    if (dirX != -1)
                    {
                        dirX = 1;
                        dirY = 0;
                    }
                    break;
                case "Left":
                    if (dirX != 1)
                    {
                        dirX = -1;
                        dirY = 0;
                    }
                    break;
                case "Up":
                    if (dirY != 1)
                    {
                        dirY = -1;
                        dirX = 0;
                    }
                    break;
                case "Down":
                    if (dirY != -1)
                    {
                        dirY = 1;
                        dirX = 0;
                    }
                    break;
                case "Space":
                    if (pause == false)
                    {
                        timer.Stop();
                        паузаToolStripMenuItem.Checked = true;
                        pause = true;
                    }
                    else if (pause == true)
                    {
                        timer.Start();
                        паузаToolStripMenuItem.Checked = false;
                        pause = false;
                    }
                    break;
            }
        }
    }
}
