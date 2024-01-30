using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace WpfApp1_RozwiazywanieQuizu.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Model.Quiz quizModel = new Model.Quiz();


        private TimerViewModel _timerViewModel;

        public MainViewModel()
        {
            _timerViewModel = new TimerViewModel();
        }

        public TimerViewModel TimerViewModel
        {
            get { return _timerViewModel; }
            set
            {
                _timerViewModel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerViewModel)));
            }
        }

        #region commands

        private ICommand startQuiz;

        public ICommand StartQuiz
        {
            get
            {
                return startQuiz ?? (startQuiz = new RelayCommand((p) =>
                {

                    for (int i = 0; i < 1000; i++)
                    {
                        isAnswer1Correct.Add(Enumerable.Repeat(false, 1000).ToList());
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        isAnswer2Correct.Add(Enumerable.Repeat(false, 1000).ToList());
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        isAnswer3Correct.Add(Enumerable.Repeat(false, 1000).ToList());
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        isAnswer4Correct.Add(Enumerable.Repeat(false, 1000).ToList());
                    }
                    if (CurrentQuestionIndex == -1)
                    {
                        //start quiz
                        BtStartText = "Zakończ";
                        IsAnsweringEnabled = true;
                        IsNextAnswerEnabled = true;
                        IsCbEnabled = false;
                        CorrectlyAnswered = 0;
                        AnswersVisible = "visible";
                        QuestionVisible = "visible";
                        SelectQuizEnable = "false";
                        IsAnswer1Checked = false;

                        QuizID = selectedQuizIndex+1;
                        CurrentQuestionIndex = 0;
                        List<List<string>> questionsWithIDs = quizModel.LoadAllQuestions(QuizID);
                        Questions = questionsWithIDs[1];
                        foreach (string ID in questionsWithIDs[0])
                        {
                            QuestionIDs.Add(Convert.ToInt32(ID));
                        }
                        int i = 0;
                        foreach (int questionID in QuestionIDs)
                        {
                            List<List<object>> answersWithIDs = quizModel.LoadAnswers(QuizID, questionID);
                            List<List<object>> questionAnswers = new List<List<object>>();
                            List<int> questionAnswersIDs = new List<int>();
                            foreach (List<object> item in answersWithIDs)
                            {
                                
                                List<int> questionNumbers = new List<int>();
                                while (questionNumbers.Count() < 4)
                                {
                                    Random rnd = new Random();                          
                                    int random = rnd.Next(1, 5);                        
                                    if (!questionNumbers.Contains(random))               
                                    {                                                   
                                        questionNumbers.Add(random);                    
                                    }                                                   
                                }                                                       
                                                                                        
                                questionAnswersIDs.Add(Convert.ToInt32(item[0]));       
                                List<object> singleAnswer = new List<object>();         
                                singleAnswer.Add(item[questionNumbers[0]]);//1          
                                singleAnswer.Add(item[questionNumbers[1]]);//2          
                                singleAnswer.Add(item[questionNumbers[2]]);             
                                singleAnswer.Add(item[questionNumbers[3]]);
                                if (item[5].ToString() == "1")
                                {
                                    if (questionNumbers[0] == 1)
                                    {
                                        SetIsAnswer1Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[1] == 1)
                                    {
                                        SetIsAnswer2Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[2] == 1)
                                    {
                                        SetIsAnswer3Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[3] == 1)
                                    {
                                        SetIsAnswer4Correct(quizID, i, true);
                                    }
                                }
                                if (item[5].ToString() == "2")
                                {
                                    if (questionNumbers[0] == 1 || questionNumbers[0] == 2)
                                    {
                                        SetIsAnswer1Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[1] == 1 || questionNumbers[1] == 2)
                                    {
                                        SetIsAnswer2Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[2] == 1 || questionNumbers[2] == 2)
                                    {
                                        SetIsAnswer3Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[3] == 1 || questionNumbers[3] == 2)
                                    {
                                        SetIsAnswer4Correct(quizID, i, true);
                                    }
                                }
                                if (item[5].ToString() == "3")
                                {
                                    if (questionNumbers[0] == 1 || questionNumbers[0] == 2 || questionNumbers[0] == 3)
                                    {
                                        SetIsAnswer1Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[1] == 1 || questionNumbers[1] == 2 || questionNumbers[1] == 3)
                                    {
                                        SetIsAnswer2Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[2] == 1 || questionNumbers[2] == 2 || questionNumbers[2] == 3)
                                    {
                                        SetIsAnswer3Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[3] == 1 || questionNumbers[3] == 2 || questionNumbers[3] == 3)
                                    {
                                        SetIsAnswer4Correct(quizID, i, true);
                                    }
                                }
                                if (item[5].ToString() == "4")
                                {
                                    if (questionNumbers[0] == 1 || questionNumbers[0] == 2 || questionNumbers[0] == 3 || questionNumbers[0] == 4)
                                    {
                                        SetIsAnswer1Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[1] == 1 || questionNumbers[1] == 2 || questionNumbers[1] == 3 || questionNumbers[1] == 4)
                                    {
                                        SetIsAnswer2Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[2] == 1 || questionNumbers[2] == 2 || questionNumbers[2] == 3 || questionNumbers[2] == 4)
                                    {
                                        SetIsAnswer3Correct(quizID, i, true);
                                    }
                                    if (questionNumbers[3] == 1 || questionNumbers[3] == 2 || questionNumbers[3] == 3 || questionNumbers[3] == 4)
                                    {
                                        SetIsAnswer4Correct(quizID, i, true);
                                    }
                                }
                                i++;
                         
                                singleAnswer.Add(item[5]);                              
                                questionAnswers.Add(singleAnswer);

                            }
                            AnswerIDs.Add(questionAnswersIDs);
                            AllAnswers.Add(questionAnswers);
                            break;
                        }
                        foreach (string question in Questions)
                        {
                            QuizQuestions.Add(question);
                        }
                            TbQuestionText = QuizQuestions[currentQuestionIndex];
                            TbAns1Text = AllAnswers[0][currentQuestionIndex][0].ToString();
                            TbAns2Text = AllAnswers[0][currentQuestionIndex][1].ToString();
                            TbAns3Text = AllAnswers[0][currentQuestionIndex][2].ToString();
                            TbAns4Text = AllAnswers[0][currentQuestionIndex][3].ToString();
                        TimerViewModel.StartTimer();
                        IsTimerVisible = "Visible";
                        TimerViewModel.SecondsElapsed = 0;
                    }
                    else
                    {
                        //stop quiz
                        BtStartText = "Rozpocznij";
                        CurrentQuestionIndex = -1;
                        QuizID = -1;
                        correctlyAnswered = 0;
                        IsAnsweringEnabled = false;
                        IsNextAnswerEnabled = false;
                        IsCbEnabled = true;
                        Questions.Clear();
                        QuestionIDs.Clear();
                        AnswerIDs.Clear();
                        AllAnswers.Clear();
                        QuizQuestions.Clear();
                        AnswersVisible = "hidden";
                        QuestionVisible = "hidden";
                        SelectQuizEnable = "true";
                        IsAnswer1Checked = false;
                        IsAnswer2Checked = false;
                        IsAnswer3Checked = false;
                        IsAnswer4Checked = false;
                        IsTimerVisible = "Hidden";
                        TimerViewModel.StopTimer();
                    }

                }, p => true));
            }
        }


        private ICommand nextQuestion;

        public ICommand NextQuestion
        {
            get
            {
                return nextQuestion ?? (nextQuestion = new RelayCommand((p) =>
                {

                    if (currentQuestionIndex < QuizQuestions.Count())
                    {
                        corectAnswerCount = 0;
                        if (GetIsAnswer1Correct(quizID, currentQuestionIndex) && isAnswer1Checked)
                        {
                            corectAnswerCount += 1;
                        }
                        if (GetIsAnswer2Correct(quizID, currentQuestionIndex) && isAnswer2Checked)
                        {
                            corectAnswerCount += 1;
                        }
                        if (GetIsAnswer3Correct(quizID,currentQuestionIndex) && isAnswer3Checked)
                        {
                            corectAnswerCount += 1;
                        }
                        if (GetIsAnswer4Correct(quizID, currentQuestionIndex) && isAnswer4Checked)
                        {
                            corectAnswerCount += 1;
                        }
                        int cos = 0;
                        if (AllAnswers[0][currentQuestionIndex][4].ToString() == "1" && corectAnswerCount==1)// && isAnswer1Checked == true && isAnswer2Checked == false && isAnswer3Checked == false && isAnswer4Checked == false)
                        {
                            correctlyAnswered++;
                        }
                        if (AllAnswers[0][currentQuestionIndex][4].ToString() == "2" && corectAnswerCount == 2)
                        {
                            correctlyAnswered++;
                        }
                        if (AllAnswers[0][currentQuestionIndex][4].ToString() == "3" && corectAnswerCount == 3)
                        {
                            correctlyAnswered++;
                        }
                        if (AllAnswers[0][currentQuestionIndex][4].ToString() == "4" && corectAnswerCount == 4)
                        {
                            correctlyAnswered++;
                        }
                        IsAnswer1Checked = false;
                        IsAnswer2Checked = false;
                        IsAnswer3Checked = false;
                        IsAnswer4Checked = false;
                    }

                    if (currentQuestionIndex + 1 < QuizQuestions.Count())
                    {
                        currentQuestionIndex++;
                        TbQuestionText = QuizQuestions[currentQuestionIndex];
                        TbAns1Text = AllAnswers[0][currentQuestionIndex][0].ToString();
                        TbAns2Text = AllAnswers[0][currentQuestionIndex][1].ToString();
                        TbAns3Text = AllAnswers[0][currentQuestionIndex][2].ToString();
                        TbAns4Text = AllAnswers[0][currentQuestionIndex][3].ToString();
                    }
                    else
                    {
                        IsNextAnswerEnabled = false;
                        //Koniec Quizu
                        TbQuestionText = "Twoje punkty: " + correctlyAnswered.ToString() + " z " + QuizQuestions.Count().ToString()+ ";   Twój czas to: "+TimerViewModel.SecondsElapsed.ToString()+" s";
                        BtStartText = "Rozpocznij Quiz";
                        currentQuestionIndex = -1;
                        QuizID = -1;
                        correctlyAnswered = 0;
                        IsAnsweringEnabled = false;
                        IsCbEnabled = true;
                        Questions.Clear();
                        QuestionIDs.Clear();
                        AnswerIDs.Clear();
                        AllAnswers.Clear();
                        QuizQuestions.Clear();
                        IsAnsweringEnabled = false;
                        IsCbEnabled = true;
                        TbAns1Text = "";
                        TbAns2Text = "";
                        TbAns3Text = "";
                        TbAns4Text = "";
                        AnswersVisible = "hidden";
                        QuestionVisible = "visible";
                        SelectQuizEnable = "true";
                        IsAnswer1Checked = false;
                        TimerViewModel.StopTimer();
                        IsTimerVisible = "Hidden";
                    }
                }, p => true));
            }
        }

        private ICommand answer1;
        public ICommand Answer1
        {
            get
            {
                return answer1 ?? (answer1 = new RelayCommand((p) =>
                {
                }, p => true));
            }
        }

        private ICommand answer2;
        public ICommand Answer2
        {
            get
            {
                return answer2 ?? (answer2 = new RelayCommand((p) =>
                {
                }, p => true));
            }
        }

        private ICommand answer3;
        public ICommand Answer3
        {
            get
            {
                return answer3 ?? (answer3 = new RelayCommand((p) =>
                {
                }, p => true));
            }
        }

        private ICommand answer4;
        public ICommand Answer4
        {
            get
            {
                return answer4 ?? (answer4 = new RelayCommand((p) =>
                {
                }, p => true));
            }
        }


        #endregion commands

        #region enables


        private string isTimerVisible = "Hidden";

        public String IsTimerVisible
        {
            get
            {
                return isTimerVisible;
            }
            set
            {
                isTimerVisible = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTimerVisible)));
            }
        }

        int corectAnswerCount = 0;

        public int CorectAnswerCount
        {
            get
            {
                return corectAnswerCount;
            }
            set
            {
                corectAnswerCount = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CorectAnswerCount)));
            }
        }


        private List<List<bool>> isAnswer1Correct = new List<List<bool>>();


        public bool GetIsAnswer1Correct(int questionID_i, int i)
        {
            return isAnswer1Correct[questionID_i][i];
        }

        public void SetIsAnswer1Correct(int questionID_i, int i, bool value)
        {
            isAnswer1Correct[questionID_i][i] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer1Correct)));
        }
        private object IsAnswer1Correct()
        {
            throw new NotImplementedException();
        }


        private List<List<bool>> isAnswer2Correct = new List<List<bool>>();


        public bool GetIsAnswer2Correct(int questionID_i, int i)
        {
            return isAnswer2Correct[questionID_i][i];
        }

        public void SetIsAnswer2Correct(int questionID_i, int i, bool value)
        {
            isAnswer2Correct[questionID_i][i] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer2Correct)));
        }
        private object IsAnswer2Correct()
        {
            throw new NotImplementedException();
        }

        private List<List<bool>> isAnswer3Correct = new List<List<bool>>();
        public bool GetIsAnswer3Correct(int questionID_i, int i)
        {
            return isAnswer3Correct[questionID_i][i];
        }

        public void SetIsAnswer3Correct(int questionID_i, int i, bool value)
        {
            isAnswer3Correct[questionID_i][i] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer3Correct)));
        }
        private object IsAnswer3Correct()
        {
            throw new NotImplementedException();
        }


        private List<List<bool>> isAnswer4Correct = new List<List<bool>>();
        public bool GetIsAnswer4Correct(int questionID_i, int i)
        {
            return isAnswer4Correct[questionID_i][i];
        }

        public void SetIsAnswer4Correct(int questionID_i, int i, bool value)
        {
            isAnswer4Correct[questionID_i][i] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer4Correct)));
        }
        private object IsAnswer4Correct()
        {
            throw new NotImplementedException();
        }




        private bool isAnswer2Corect = false;

        public bool IsAnswer2Corect
        {
            get
            {
                return isAnswer2Corect;
            }
            set
            {
                isAnswer2Corect = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer2Corect)));
            }
        }
        private bool isAnswer3Corect = false;

        public bool IsAnswer3Corect
        {
            get
            {
                return isAnswer3Corect;
            }
            set
            {
                isAnswer3Corect = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer3Corect)));
            }
        }
        private bool isAnswer4Corect = false;

        public bool IsAnswer4Corect
        {
            get
            {
                return isAnswer4Corect;
            }
            set
            {
                isAnswer4Corect = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer4Corect)));
            }
        }

        private bool isAnswer1Checked = false;

        public bool IsAnswer1Checked
        {
            get
            {
                return isAnswer1Checked;
            }
            set
            {
                isAnswer1Checked = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer1Checked)));
            }
        }

        private bool isAnswer2Checked = false;

        public bool IsAnswer2Checked
        {
            get
            {
                return isAnswer2Checked;
            }
            set
            {
                isAnswer2Checked = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer2Checked)));
            }
        }

        private bool isAnswer3Checked = false;

        public bool IsAnswer3Checked
        {
            get
            {
                return isAnswer3Checked;
            }
            set
            {
                isAnswer3Checked = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer3Checked)));
            }
        }

        private bool isAnswer4Checked = false;

        public bool IsAnswer4Checked
        {
            get
            {
                return isAnswer4Checked;
            }
            set
            {
                isAnswer4Checked = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnswer4Checked)));
            }
        }

        private bool isStartQuizEnabled = false;

        public bool IsStartQuizEnabled
        {
            get
            {
                return isStartQuizEnabled;
            }
            set
            {
                isStartQuizEnabled = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsStartQuizEnabled)));
            }
        }

        private string answersVisible = "Hidden";

        public String AnswersVisible
        {
            get
            {
                return answersVisible;
            }
            set
            {
                answersVisible = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnswersVisible)));
            }
        }

        private string questionVisible = "Hidden";

        public String QuestionVisible
        {
            get
            {
                return questionVisible;
            }
            set
            {
                questionVisible = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionVisible)));
            }
        }

        private string selectQuizEnable = "true";

        public String SelectQuizEnable
        {
            get
            {
                return selectQuizEnable;
            }
            set
            {
                selectQuizEnable = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectQuizEnable)));
            }
        }



        private bool isAnsweringEnabled = false;

        public bool IsAnsweringEnabled
        {
            get
            {
                return isAnsweringEnabled;
            }
            set
            {
                isAnsweringEnabled = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnsweringEnabled)));
            }
        }

        private bool isNextAnswerEnabled = false;

        public bool IsNextAnswerEnabled
        {
            get
            {
                return isNextAnswerEnabled;
            }
            set
            {
                isNextAnswerEnabled = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNextAnswerEnabled)));
            }
        }

        private bool isCbEnabled = true;

        public bool IsCbEnabled
        {
            get
            {
                return isCbEnabled;
            }
            set
            {
                isCbEnabled = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCbEnabled)));
            }
        }


        #endregion enables

        #region textes

        private string tbQuestionText = "";

        public String TbQuestionText
        {
            get
            {
                return tbQuestionText;
            }
            set
            {
                tbQuestionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TbQuestionText)));
            }
        }

        private string btStartText = "Rozpocznij Quiz";

        public String BtStartText
        {
            get
            {
                return btStartText;
            }
            set
            {
                btStartText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BtStartText)));
            }
        }

        private string tbAns1Text = "";

        public String TbAns1Text
        {
            get
            {
                return tbAns1Text;
            }
            set
            {
                tbAns1Text = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TbAns1Text)));
            }
        }

        private string tbAns2Text = "";

        public String TbAns2Text
        {
            get
            {
                return tbAns2Text;
            }
            set
            {
                tbAns2Text = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TbAns2Text)));
            }
        }

        private string tbAns3Text = "";

        public String TbAns3Text
        {
            get
            {
                return tbAns3Text;
            }
            set
            {
                tbAns3Text = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TbAns3Text)));
            }
        }

        private string tbAns4Text = "";

        public String TbAns4Text
        {
            get
            {
                return tbAns4Text;
            }
            set
            {
                tbAns4Text = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TbAns4Text)));
            }
        }


        #endregion textes

        #region variables

        private int selectedQuizIndex = -1;
        public int SelectedQuizIndex
        {
            get
            {
                return selectedQuizIndex;
            }
            set
            {
                selectedQuizIndex = value;
                if (selectedQuizIndex == -1)
                {
                    IsStartQuizEnabled = false;
                }
                else
                {
                    IsStartQuizEnabled = true;
                }
            }
        }

        private int currentQuestionIndex = -1;
        public int CurrentQuestionIndex
        {
            get
            {
                return currentQuestionIndex;
            }
            set
            {
                currentQuestionIndex = value;
            }
        }

        private int correctlyAnswered = 0;
        public int CorrectlyAnswered
        {
            get
            {
                return correctlyAnswered;
            }
            set
            {
                correctlyAnswered = value;
            }
        }

        private List<string> questions = new List<string>();

        public List<string> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
            }
        }

        private List<List<string>> answers = new List<List<string>>();

        public List<List<string>> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
            }
        }

        private List<string> avilableQuizes = new List<string>();
        public List<string> AvilableQuizes
        {
            get
            {
                return avilableQuizes;
            }
            set
            {
                avilableQuizes = value;
            }
        }

        private ObservableCollection<String> avilableQuizesNames = new ObservableCollection<String>();
        public ObservableCollection<String> AvilableQuizesNames
        {
            get
            {
                AvilableQuizes = quizModel.LoadQuizes();
                foreach (string quiz in AvilableQuizes)
                {
                    avilableQuizesNames.Add(quiz);
                }
                return avilableQuizesNames;
            }
            set
            {
                AvilableQuizesNames = value;
            }
        }

        private List<int> questionIDs = new List<int>();

        public List<int> QuestionIDs
        {
            get
            {
                return questionIDs;
            }
            set
            {
                questionIDs = value;
            }
        }

        private int quizID = -1;
        public int QuizID
        {
            get
            {
                return quizID;
            }
            set
            {
                quizID = value;
            }
        }

        private List<List<int>> answerIDs = new List<List<int>>();
        public List<List<int>> AnswerIDs
        {
            get
            {
                return answerIDs;
            }
            set
            {
                answerIDs = value;
            }
        }


        private List<List<List<object>>> allAnswers = new List<List<List<object>>>();
        public List<List<List<object>>> AllAnswers
        {
            get
            {
                return allAnswers;
            }
            set
            {
                allAnswers = value;
            }
        }

        private ObservableCollection<string> quizQuestions = new ObservableCollection<string>();
        public ObservableCollection<string> QuizQuestions
        {
            get
            {
                return quizQuestions;
            }
            set
            {
                quizQuestions = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizQuestions)));
            }
        }



        #endregion

    }
}
