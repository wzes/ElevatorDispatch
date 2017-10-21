using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ElevatorDispatch
{
    
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Elevator firstElevator;
        Elevator secondElevator;
        Elevator thirdElevator;
        Elevator fourthElevator;
        Elevator fifthElevator;
        List<Elevator> elevators;  //电梯实例
        FloorWork floorWork;
        DispatcherTimer elevatorFirstTimer;
        DispatcherTimer elevatorSecondTimer;
        DispatcherTimer elevatorThirdTimer;
        DispatcherTimer elevatorFourthTimer;
        DispatcherTimer elevatorFifthTimer;
        public static Double shortTIME = 0.04;
        public static Double longTIME = 5;


        static int moveFirst = 0;
        static int moveSecond = 0;
        static int moveThird= 0;
        static int moveFourth = 0;
        static int moveFifth = 0;

        public static Dictionary<int,int> HeightFloor = new Dictionary<int, int>();
        public static Dictionary<int, int> FloorHeight = new Dictionary<int, int>();
        public MainWindow()
        {
            
            InitializeComponent();
            
            init();
            initElevatorFirst();
            initElevatorSecond();
            initElevatorThird();
            initElevatorFourth();
            initElevatorFifth();
            
        }
        
        /*
        *设置
        */
        public void Set()
        {
            setting setFrom = new setting();
            setFrom.ShowDialog();
        }

        /*
        *第一个电梯的初始化
        */
        public void initElevatorFirst()
        {
            elevatorFirstTimer = new DispatcherTimer();
            elevatorFirstTimer.Interval = TimeSpan.FromSeconds(0.1);
            elevatorFirstTimer.Tick += new EventHandler(elevatorFirstTimer_Tick);

            
            Vector vector = VisualTreeHelper.GetOffset(elevator_first);
            moveFirst = (int)vector.Y;         
            firstElevator.setCurrentFloor(1);
           
           
        }

        /*
        *清除电梯的任务
        */
        public void initElevator(int number, int Floor, int Derec)
        {
            switch (Floor)
            {
                case 20:
                    switch (number)
                    {
                        case 1:
                            elevator_one_twenty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_twenty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_twenty.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_twenty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_twenty.IsEnabled = true;
                            break;

                    }
                    
                    elevator_one_twenty_down.Background = Brushes.Silver;
                    elevator_two_twenty_down.Background = Brushes.Silver;
                    elevator_three_twenty_down.Background = Brushes.Silver;
                    elevator_four_twenty_down.Background = Brushes.Silver;
                    elevator_five_twenty_down.Background = Brushes.Silver;
                    break;
                case 19:   
                    switch (number)
                    {
                        case 1:
                            elevator_one_ninty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_ninty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_ninty.IsEnabled = true; 
                            break;
                        case 4:
                            elevator_four_ninty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_ninty.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_ninty_up.Background = Brushes.Silver;
                        elevator_two_ninty_up.Background = Brushes.Silver;
                        elevator_three_ninty_up.Background = Brushes.Silver;
                        elevator_four_ninty_up.Background = Brushes.Silver;
                        elevator_five_ninty_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_ninty_down.Background = Brushes.Silver;
                        elevator_two_ninty_down.Background = Brushes.Silver;
                        elevator_three_ninty_down.Background = Brushes.Silver;
                        elevator_four_ninty_down.Background = Brushes.Silver;
                        elevator_five_ninty_down.Background = Brushes.Silver;

                    }



                    break;
                case 18: 
                    switch (number)
                    {
                        case 1:
                            elevator_one_eighty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_eighty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_eighty.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_eighty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_eighty.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_eighty_up.Background = Brushes.Silver;
                        elevator_two_eighty_up.Background = Brushes.Silver;
                        elevator_three_eighty_up.Background = Brushes.Silver;
                        elevator_four_eighty_up.Background = Brushes.Silver;
                        elevator_five_eighty_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_eighty_down.Background = Brushes.Silver;
                        elevator_two_eighty_down.Background = Brushes.Silver;
                        elevator_three_eighty_down.Background = Brushes.Silver;
                        elevator_four_eighty_down.Background = Brushes.Silver;
                        elevator_five_eighty_down.Background = Brushes.Silver;

                    }

                    break;
                case 17:
                    switch (number)
                    {
                        case 1:
                            elevator_one_seventy.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_seventy.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_seventy.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_seventy.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_seventy.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_seventy_up.Background = Brushes.Silver;
                        elevator_two_seventy_up.Background = Brushes.Silver;
                        elevator_three_seventy_up.Background = Brushes.Silver;
                        elevator_four_seventy_up.Background = Brushes.Silver;
                        elevator_five_seventy_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_seventy_down.Background = Brushes.Silver;
                        elevator_two_seventy_down.Background = Brushes.Silver;
                        elevator_three_seventy_down.Background = Brushes.Silver;
                        elevator_four_seventy_down.Background = Brushes.Silver;
                        elevator_five_seventy_down.Background = Brushes.Silver;
                    }

                    break;
                case 16:
                    switch (number)
                    {
                        case 1:
                            elevator_one_sixty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_sixty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_sixty.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_sixty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_sixty.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_sixty_up.Background = Brushes.Silver;
                        elevator_two_sixty_up.Background = Brushes.Silver;
                        elevator_three_sixty_up.Background = Brushes.Silver;
                        elevator_four_sixty_up.Background = Brushes.Silver;
                        elevator_five_sixty_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_sixty_down.Background = Brushes.Silver;
                        elevator_two_sixty_down.Background = Brushes.Silver;
                        elevator_three_sixty_down.Background = Brushes.Silver;
                        elevator_four_sixty_down.Background = Brushes.Silver;
                        elevator_five_sixty_down.Background = Brushes.Silver;
                    }

                    break;
                case 15:
                    switch (number)
                    {
                        case 1:
                            elevator_one_fifty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_fifty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_fifty.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_fifty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_fifty.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_fifty_up.Background = Brushes.Silver;
                        elevator_two_fifty_up.Background = Brushes.Silver;
                        elevator_three_fifty_up.Background = Brushes.Silver;
                        elevator_four_fifty_up.Background = Brushes.Silver;
                        elevator_five_fifty_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_fifty_down.Background = Brushes.Silver;
                        elevator_two_fifty_down.Background = Brushes.Silver;
                        elevator_three_fifty_down.Background = Brushes.Silver;
                        elevator_four_fifty_down.Background = Brushes.Silver;
                        elevator_five_fifty_down.Background = Brushes.Silver;
                    }

                    break;
                case 14:
                    switch (number)
                    {
                        case 1:
                            elevator_one_fouty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_fouty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_fouty.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_fouty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_fouty.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_forty_up.Background = Brushes.Silver;
                        elevator_two_forty_up.Background = Brushes.Silver;
                        elevator_three_forty_up.Background = Brushes.Silver;
                        elevator_four_forty_up.Background = Brushes.Silver;
                        elevator_five_forty_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_forty_down.Background = Brushes.Silver;
                        elevator_two_forty_down.Background = Brushes.Silver;
                        elevator_three_forty_down.Background = Brushes.Silver;
                        elevator_four_forty_down.Background = Brushes.Silver;
                        elevator_five_forty_down.Background = Brushes.Silver;
                    }
                    break;
                case 13:
                    switch (number)
                    {
                        case 1:
                            elevator_one_thirty.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_thirty.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_thirty.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_thirty.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_thirty.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_thirty_up.Background = Brushes.Silver;
                        elevator_two_thirty_up.Background = Brushes.Silver;
                        elevator_three_thirty_up.Background = Brushes.Silver;
                        elevator_four_thirty_up.Background = Brushes.Silver;
                        elevator_five_thirty_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_thirty_down.Background = Brushes.Silver;
                        elevator_two_thirty_down.Background = Brushes.Silver;
                        elevator_three_thirty_down.Background = Brushes.Silver;
                        elevator_four_thirty_down.Background = Brushes.Silver;
                        elevator_five_thirty_down.Background = Brushes.Silver;
                    }
                    break;
                case 12:
                    switch (number)
                    {
                        case 1:
                            elevator_one_twelve.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_twelve.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_twelve.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_twelve.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_twelve.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_twelve_up.Background = Brushes.Silver;
                        elevator_two_twelve_up.Background = Brushes.Silver;
                        elevator_three_twelve_up.Background = Brushes.Silver;
                        elevator_four_twelve_up.Background = Brushes.Silver;
                        elevator_five_twelve_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_twelve_down.Background = Brushes.Silver;
                        elevator_two_twelve_down.Background = Brushes.Silver;
                        elevator_three_twelve_down.Background = Brushes.Silver;
                        elevator_four_twelve_down.Background = Brushes.Silver;
                        elevator_five_twelve_down.Background = Brushes.Silver;
                    }
                    break;
                case 11:
                    switch (number)
                    {
                        case 1:
                            elevator_one_eleven.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_eleven.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_eleven.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_eleven.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_eleven.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_eleven_up.Background = Brushes.Silver;
                        elevator_two_eleven_up.Background = Brushes.Silver;
                        elevator_three_eleven_up.Background = Brushes.Silver;
                        elevator_four_eleven_up.Background = Brushes.Silver;
                        elevator_five_eleven_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_eleven_down.Background = Brushes.Silver;
                        elevator_two_eleven_down.Background = Brushes.Silver;
                        elevator_three_eleven_down.Background = Brushes.Silver;
                        elevator_four_eleven_down.Background = Brushes.Silver;
                        elevator_five_eleven_down.Background = Brushes.Silver;
                    }
                    break;
                case 10:
                    switch (number)
                    {
                        case 1:
                            elevator_one_ten.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_ten.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_ten.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_ten.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_ten.IsEnabled = true;
                            break;

                    }

                    if (Derec == Elevator.UP)
                    {
                        elevator_one_ten_up.Background = Brushes.Silver;
                        elevator_two_ten_up.Background = Brushes.Silver;
                        elevator_three_ten_up.Background = Brushes.Silver;
                        elevator_four_ten_up.Background = Brushes.Silver;
                        elevator_five_ten_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_ten_down.Background = Brushes.Silver;
                        elevator_two_ten_down.Background = Brushes.Silver;
                        elevator_three_ten_down.Background = Brushes.Silver;
                        elevator_four_ten_down.Background = Brushes.Silver;
                        elevator_five_ten_down.Background = Brushes.Silver;
                    }
                    break;
                case 9:
                    switch (number)
                    {
                        case 1:
                            elevator_one_nine.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_nine.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_nine.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_nine.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_nine.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_nine_up.Background = Brushes.Silver;
                        elevator_two_nine_up.Background = Brushes.Silver;
                        elevator_three_nine_up.Background = Brushes.Silver;
                        elevator_four_nine_up.Background = Brushes.Silver;
                        elevator_five_nine_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_nine_down.Background = Brushes.Silver;
                        elevator_two_nine_down.Background = Brushes.Silver;
                        elevator_three_nine_down.Background = Brushes.Silver;
                        elevator_four_nine_down.Background = Brushes.Silver;
                        elevator_five_nine_down.Background = Brushes.Silver;
                    }
                    break;
                case 8:
                    switch (number)
                    {
                        case 1:
                            elevator_one_eight.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_eight.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_eight.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_eight.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_eight.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_eight_up.Background = Brushes.Silver;
                        elevator_two_eight_up.Background = Brushes.Silver;
                        elevator_three_eight_up.Background = Brushes.Silver;
                        elevator_four_eight_up.Background = Brushes.Silver;
                        elevator_five_eight_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_eight_down.Background = Brushes.Silver;
                        elevator_two_eight_down.Background = Brushes.Silver;
                        elevator_three_eight_down.Background = Brushes.Silver;
                        elevator_four_eight_down.Background = Brushes.Silver;
                        elevator_five_eight_down.Background = Brushes.Silver;
                    }
                    break;
                case 7:
                    switch (number)
                    {
                        case 1:
                            elevator_one_seven.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_seven.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_seven.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_seven.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_seven.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_seven_up.Background = Brushes.Silver;
                        elevator_two_seven_up.Background = Brushes.Silver;
                        elevator_three_seven_up.Background = Brushes.Silver;
                        elevator_four_seven_up.Background = Brushes.Silver;
                        elevator_five_seven_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_seven_down.Background = Brushes.Silver;
                        elevator_two_seven_down.Background = Brushes.Silver;
                        elevator_three_seven_down.Background = Brushes.Silver;
                        elevator_four_seven_down.Background = Brushes.Silver;
                        elevator_five_seven_down.Background = Brushes.Silver;
                    }
                    break;
                case 6:
                    switch (number)
                    {
                        case 1:
                            elevator_one_six.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_six.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_six.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_six.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_six.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_six_up.Background = Brushes.Silver;
                        elevator_two_six_up.Background = Brushes.Silver;
                        elevator_three_six_up.Background = Brushes.Silver;
                        elevator_four_six_up.Background = Brushes.Silver;
                        elevator_five_six_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_six_down.Background = Brushes.Silver;
                        elevator_two_six_down.Background = Brushes.Silver;
                        elevator_three_six_down.Background = Brushes.Silver;
                        elevator_four_six_down.Background = Brushes.Silver;
                        elevator_five_six_down.Background = Brushes.Silver;
                    }
                   break;
                case 5:
                    switch (number)
                    {
                        case 1:
                            elevator_one_five.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_five.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_five.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_five.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_five.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_five_up.Background = Brushes.Silver;
                        elevator_two_five_up.Background = Brushes.Silver;
                        elevator_three_five_up.Background = Brushes.Silver;
                        elevator_four_five_up.Background = Brushes.Silver;
                        elevator_five_five_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_five_down.Background = Brushes.Silver;
                        elevator_two_five_down.Background = Brushes.Silver;
                        elevator_three_five_down.Background = Brushes.Silver;
                        elevator_four_five_down.Background = Brushes.Silver;
                        elevator_five_five_down.Background = Brushes.Silver;
                    }
                 
                    break;
                case 4:
                    switch (number)
                    {
                        case 1:
                            elevator_one_four.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_four.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_four.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_four.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_four.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_four_up.Background = Brushes.Silver;
                        elevator_two_four_up.Background = Brushes.Silver;
                        elevator_three_four_up.Background = Brushes.Silver;
                        elevator_four_four_up.Background = Brushes.Silver;
                        elevator_five_four_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_four_down.Background = Brushes.Silver;
                        elevator_two_four_down.Background = Brushes.Silver;
                        elevator_three_four_down.Background = Brushes.Silver;
                        elevator_four_four_down.Background = Brushes.Silver;
                        elevator_five_four_down.Background = Brushes.Silver;
                    }
                  
                    break;
                case 3:
                    switch (number)
                    {
                        case 1:
                            elevator_one_three.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_three.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_three.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_three.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_three.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_three_up.Background = Brushes.Silver;
                        elevator_two_three_up.Background = Brushes.Silver;
                        elevator_three_three_up.Background = Brushes.Silver;
                        elevator_four_three_up.Background = Brushes.Silver;
                        elevator_five_three_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_three_down.Background = Brushes.Silver;
                        elevator_two_three_down.Background = Brushes.Silver;
                        elevator_three_three_down.Background = Brushes.Silver;
                        elevator_four_three_down.Background = Brushes.Silver;
                        elevator_five_three_down.Background = Brushes.Silver;
                    }
                    break;
                case 2:
                    switch (number)
                    {
                        case 1:
                            elevator_one_two.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_two.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_two.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_two.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_two.IsEnabled = true;
                            break;

                    }
                    if (Derec == Elevator.UP)
                    {
                        elevator_one_two_up.Background = Brushes.Silver;
                        elevator_two_two_up.Background = Brushes.Silver;
                        elevator_three_two_up.Background = Brushes.Silver;
                        elevator_four_two_up.Background = Brushes.Silver;
                        elevator_five_two_up.Background = Brushes.Silver;
                    }
                    else
                    {
                        elevator_one_two_down.Background = Brushes.Silver;
                        elevator_two_two_down.Background = Brushes.Silver;
                        elevator_three_two_down.Background = Brushes.Silver;
                        elevator_four_two_down.Background = Brushes.Silver;
                        elevator_five_two_down.Background = Brushes.Silver;
                    }
                    
                    break;
                case 1: 
                    switch (number)
                    {
                        case 1:
                            elevator_one_one.IsEnabled = true;
                            break;
                        case 2:
                            elevator_two_one.IsEnabled = true;
                            break;
                        case 3:
                            elevator_three_one.IsEnabled = true;
                            break;
                        case 4:
                            elevator_four_one.IsEnabled = true;
                            break;
                        case 5:
                            elevator_five_one.IsEnabled = true;
                            break;

                    }
                    elevator_one_one_up.Background = Brushes.Silver;
                    elevator_two_one_up.Background = Brushes.Silver;
                    elevator_three_one_up.Background = Brushes.Silver;
                    elevator_four_one_up.Background = Brushes.Silver;
                    elevator_five_one_up.Background = Brushes.Silver;
                    break;
            }
        }
        /*
        *第一个电梯的运行
        */
        public void elevatorFirstTimer_Tick(object sender, EventArgs e)
        {
            Vector vector = VisualTreeHelper.GetOffset(elevator_first);
            moveFirst = (int)vector.Y;
            //有任务
            if (firstElevator.getDownStops().Count != 0)
            {
                int Floor = HeightFloor[moveFirst];
                int Derec = firstElevator.getDerection();
                firstElevator.setCurrentFloor(Floor);
                Work work = firstElevator.getCurrentWork(Floor);
                Work w = floorWork.getCurrrentWork(Derec, Floor);
                if (floorWork.checkStops(elevators, Derec, Floor))
                {
                    elevatorFirstTimer.Stop();   //停止
                    first.Content = "电梯 1 " + "已到达第" + Floor + "层 ！";
                    if (w!=null)
                    initElevator(1, Floor, w.getDerection());   //初始化
                    elevatorFirstTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (firstElevator.getDownStops().Count == 0)
                    {
                        firstElevator.setDerection(Elevator.STOP);
                        elevatorFirstTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorFirstTimer.Start();
                    }
                }
                //达到任务层
                else if (firstElevator.isWaiting(Derec, Floor) && moveFirst + 1 == FloorHeight[Floor])
                {
                    elevatorFirstTimer.Stop(); //停止
                    first.Content = "电梯 1 " + "已到达第" + Floor + "层 ！";
                    firstElevator.removeWork(work.getDerection(), Floor);  //取消该层的任务
                    if (work != null)
                    {
                        initElevator(1, Floor, work.getDerection());   //初始化
                        elevatorFirstTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    }
                    if (firstElevator.getDownStops().Count == 0)
                    {
                        firstElevator.setDerection(Elevator.STOP);
                        elevatorFirstTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorFirstTimer.Start(); 
                    }
                }
                else
                {
                    elevatorFirstTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    if (firstElevator.getDownStops()[firstElevator.getMax()].getDestination() <= firstElevator.getCurrentFloor())
                    {
                        first.Content = "正在往下";
                        firstElevator.setDerection(Elevator.DOWN);
                        moveFirst += 1;
                        Thickness thickness = new Thickness();
                        elevator_first.Content = HeightFloor[moveFirst]; //显示楼层
                        thickness.Top = moveFirst;
                        thickness.Left = vector.X;
                        elevator_first.Margin = thickness;
                    }
                    else
                    {
                        first.Content = "正在往上";
                        firstElevator.setDerection(Elevator.UP);
                        moveFirst -= 1;
                        Thickness thickness = new Thickness();
                        elevator_first.Content = HeightFloor[moveFirst]; //显示楼层
                        thickness.Top = moveFirst;
                        thickness.Left = vector.X;
                        elevator_first.Margin = thickness;
                    }
                }
            }
            else
            {
                int Floor = HeightFloor[moveFirst];
                int height = FloorHeight[Floor];
                if (moveFirst > height && moveFirst < 533)
                {
                    first.Content = "正在往下";
                    firstElevator.setDerection(Elevator.DOWN);
                    Thickness thickness = new Thickness();
                    elevator_first.Content = HeightFloor[moveFirst]; //显示楼层
                    moveFirst += 1;
                    thickness.Top = moveFirst;
                    thickness.Left = vector.X;
                    elevator_first.Margin = thickness;
                }
                else if(moveFirst < height && moveFirst > 0)
                {
                    first.Content = "正在往上";
                    firstElevator.setDerection(Elevator.UP);
                    moveFirst -= 1;
                    Thickness thickness = new Thickness();
                    elevator_first.Content = HeightFloor[moveFirst]; //显示楼层
                    thickness.Top = moveFirst;
                    thickness.Left = vector.X;
                    elevator_first.Margin = thickness;
                }
                 else
                {
                    firstElevator.setDerection(Elevator.STOP);
                    elevatorFirstTimer.Stop();
                }
            }
        }
        /*
        *第二个电梯的初始化
        */
        public void initElevatorSecond()
        {
            elevatorSecondTimer = new DispatcherTimer();
            elevatorSecondTimer.Interval = TimeSpan.FromSeconds(0.1);
            elevatorSecondTimer.Tick += new EventHandler(elevatorSecondTimer_Tick);
            Vector vector = VisualTreeHelper.GetOffset(elevator_second);
            moveSecond = (int)vector.Y;
            secondElevator.setCurrentFloor(1);
        }
        
        /*
        *第二个电梯的运行
        */
        public void elevatorSecondTimer_Tick(object sender, EventArgs e)
        {
            Vector vector = VisualTreeHelper.GetOffset(elevator_second);
            moveSecond = (int)vector.Y;
            
            //有任务
            if (secondElevator.getDownStops().Count != 0)
            {
                int Floor = HeightFloor[moveSecond];
                int Derec = secondElevator.getDerection();
                secondElevator.setCurrentFloor(Floor);
                Work work = secondElevator.getCurrentWork(Floor);
                //达到任务层
                Work w = floorWork.getCurrrentWork(Derec, Floor);
                if (floorWork.checkStops(elevators, Derec, Floor))
                {
                    elevatorSecondTimer.Stop();   //停止
                    second.Content = "电梯 2 " + "已到达第" + Floor + "层 ！";
                    initElevator(2, Floor, w.getDerection());   //初始化
                    elevatorSecondTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (secondElevator.getDownStops().Count == 0)
                    {
                        secondElevator.setDerection(Elevator.STOP);
                        elevatorSecondTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorSecondTimer.Start();
                    }
                }
                else if (secondElevator.isWaiting(Derec, Floor) && moveSecond + 1 == FloorHeight[Floor])
                {
                    elevatorSecondTimer.Stop();
                    second.Content = "电梯 2 " + "已到达第" + Floor + "层 ！";
                    if (work != null)
                    {
                        initElevator(2, Floor, work.getDerection());   //初始化
                        secondElevator.removeWork(work.getDerection(), Floor);
                    }
                    elevatorSecondTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (secondElevator.getDownStops().Count == 0)
                    {
                        secondElevator.setDerection(Elevator.STOP);
                        elevatorSecondTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorSecondTimer.Start();
                    }
                }
                else
                {
                    elevatorSecondTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    if (secondElevator.getDownStops()[secondElevator.getMax()].getDestination() <= secondElevator.getCurrentFloor())
                    {
                        second.Content = "正在往下";
                        secondElevator.setDerection(Elevator.DOWN);
                        moveSecond += 1;
                        Thickness thickness = new Thickness();
                        elevator_second.Content = HeightFloor[moveSecond]; //显示楼层
                        thickness.Top = moveSecond;
                        thickness.Left = vector.X;
                        elevator_second.Margin = thickness;  
                    }
                    else
                    {
                        second.Content = "正在往上";
                        secondElevator.setDerection(Elevator.UP);
                        moveSecond -= 1;
                        Thickness thickness = new Thickness();
                        elevator_second.Content = HeightFloor[moveSecond]; //显示楼层
                        thickness.Top = moveSecond;
                        thickness.Left = vector.X;
                        elevator_second.Margin = thickness;
                    }
          
                }

            }
            else
            {
                int Floor = HeightFloor[moveSecond];
                if (moveSecond > FloorHeight[Floor] && moveSecond < 533)
                {
                    second.Content = "正在往下";
                    secondElevator.setDerection(Elevator.DOWN);
                    moveSecond += 1;
                    Thickness thickness = new Thickness();
                    elevator_second.Content = HeightFloor[moveSecond]; //显示楼层
                    thickness.Top = moveSecond;
                    thickness.Left = vector.X;
                    elevator_second.Margin = thickness;
                }
                else if(moveSecond < FloorHeight[Floor] && moveSecond > 0)
                {
                    second.Content = "正在往上";
                    secondElevator.setDerection(Elevator.UP);
                    moveSecond -= 1;
                    Thickness thickness = new Thickness();
                    elevator_second.Content = HeightFloor[moveSecond]; //显示楼层
                    thickness.Top = moveSecond;
                    thickness.Left = vector.X;
                    elevator_second.Margin = thickness;
                }
                else
                {
                    secondElevator.setDerection(Elevator.STOP);
                    elevatorSecondTimer.Stop();
                }
            }

        }
        /*
        *第三个电梯的初始化
        */
        public void initElevatorThird()
        {
            elevatorThirdTimer = new DispatcherTimer();
            elevatorThirdTimer.Interval = TimeSpan.FromSeconds(0.1);
            elevatorThirdTimer.Tick += new EventHandler(elevatorThirdTimer_Tick);
           
            Vector vector = VisualTreeHelper.GetOffset(elevator_third);
            moveThird = (int)vector.Y;
            thirdElevator.setCurrentFloor(1);
            Console.Write(HeightFloor[moveThird] + "\n");
        }
       
        /*
        *第三个电梯的运行
        */
        public void elevatorThirdTimer_Tick(object sender, EventArgs e)
        {
            Vector vector = VisualTreeHelper.GetOffset(elevator_third);
            moveThird = (int)vector.Y;
           
            //有任务
            if (thirdElevator.getDownStops().Count != 0)
            {

                int Floor = HeightFloor[moveThird];
                int Derec = thirdElevator.getDerection();
                thirdElevator.setCurrentFloor(Floor);
                Work work = thirdElevator.getCurrentWork(Floor);
                Work w = floorWork.getCurrrentWork(Derec, Floor);
                //达到任务层
                if (floorWork.checkStops(elevators, Derec, Floor))
                {
                    elevatorThirdTimer.Stop();   //停止
                    third.Content = "电梯 3 " + "已到达第" + Floor + "层 ！";
                    if (w != null)
                    initElevator(3, Floor, w.getDerection());   //初始化
                    elevatorThirdTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (thirdElevator.getDownStops().Count == 0)
                    {
                        thirdElevator.setDerection(Elevator.STOP);
                        elevatorThirdTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorThirdTimer.Start();
                    }
                }
                else if (thirdElevator.isWaiting(Derec, Floor) && moveThird + 1 == FloorHeight[Floor])
                {
                    elevatorThirdTimer.Stop();
                    third.Content = "电梯 3 " + "已到达第" + Floor + "层 ！";
                    if (work != null)
                    {
                        thirdElevator.removeWork(work.getDerection(), Floor);
                        initElevator(3, Floor, work.getDerection());
                    }
                    elevatorThirdTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (thirdElevator.getDownStops().Count == 0)
                    {
                        thirdElevator.setDerection(Elevator.STOP);
                        elevatorThirdTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorThirdTimer.Start();
                    }
                }
                else
                {
                    elevatorThirdTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    if (thirdElevator.getDownStops()[thirdElevator.getMax()].getDestination() <= thirdElevator.getCurrentFloor())
                    {
                        third.Content = "正在往下";
                        thirdElevator.setDerection(Elevator.DOWN);
                        moveThird += 1;
                        Thickness thickness = new Thickness();
                        elevator_third.Content = HeightFloor[moveThird]; //显示楼层
                        thickness.Top = moveThird;
                        thickness.Left = vector.X;
                        elevator_third.Margin = thickness;
                    }
                    else
                    {
                        third.Content = "正在往上";
                        thirdElevator.setDerection(Elevator.UP);
                        moveThird -= 1;
                        Thickness thickness = new Thickness();
                        elevator_third.Content = HeightFloor[moveThird]; //显示楼层
                        thickness.Top = moveThird;
                        thickness.Left = vector.X;
                        elevator_third.Margin = thickness;
                    }
                }
            }
            else
            {
                int Floor = HeightFloor[moveThird];
                if (moveThird > FloorHeight[Floor] && moveThird < 533)
                {
                    third.Content = "正在往下";
                    thirdElevator.setDerection(Elevator.DOWN);
                    moveThird += 1;
                    Thickness thickness = new Thickness();
                    elevator_third.Content = HeightFloor[moveThird]; //显示楼层
                    thickness.Top = moveThird;
                    thickness.Left = vector.X;
                    elevator_third.Margin = thickness;
                }
                else if (moveThird < FloorHeight[Floor] && moveThird  > 0)
                {
                    third.Content = "正在往上";
                    thirdElevator.setDerection(Elevator.UP);
                    moveThird -= 1;
                    Thickness thickness = new Thickness();
                    elevator_third.Content = HeightFloor[moveThird]; //显示楼层
                    thickness.Top = moveThird;
                    thickness.Left = vector.X;
                    elevator_third.Margin = thickness;
                }
                 else
                {
                    thirdElevator.setDerection(Elevator.STOP);
                    elevatorThirdTimer.Stop();
                }
            }
        }
        /*
        *第四个电梯的初始化
        */
        public void initElevatorFourth()
        {
            elevatorFourthTimer = new DispatcherTimer();
            elevatorFourthTimer.Interval = TimeSpan.FromSeconds(0.1);
            elevatorFourthTimer.Tick += new EventHandler(elevatorFourthTimer_Tick);
            //elevatorFourthTimer.Start();
            Vector vector = VisualTreeHelper.GetOffset(elevator_fourth);
            moveFourth = (int)vector.Y;
            //secondElevator.setCurrentFloor(HeightFloor[moveSecond]);
            fourthElevator.setCurrentFloor(1);
            //Console.Write(HeightFloor[moveFourth] + "\n");
        }
        
        /*
        *第四个电梯的运行
        */
        public void elevatorFourthTimer_Tick(object sender, EventArgs e)
        {
            Vector vector = VisualTreeHelper.GetOffset(elevator_fourth);
            moveFourth = (int)vector.Y;
            
            //有任务
            if (fourthElevator.getDownStops().Count != 0)
            {
                int Floor = HeightFloor[moveFourth];
                int Derec = fourthElevator.getDerection();
                fourthElevator.setCurrentFloor(Floor);
                Work work = fourthElevator.getCurrentWork(Floor);
                Work w = floorWork.getCurrrentWork(Derec, Floor);
                //达到任务层
                if (floorWork.checkStops(elevators, Derec, Floor))
                {
                    elevatorFourthTimer.Stop();   //停止
                    fourth.Content = "电梯 4 " + "已到达第" + Floor + "层 ！";
                    if (w != null)
                    initElevator(4, Floor, w.getDerection());   //初始化
                    elevatorFourthTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (fourthElevator.getDownStops().Count == 0)
                    {
                        fourthElevator.setDerection(Elevator.STOP);
                        elevatorFourthTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorFourthTimer.Start();
                    }
                }
                else if (fourthElevator.isWaiting(Derec, Floor) && moveFourth + 1 == FloorHeight[Floor])
                {
                    elevatorFourthTimer.Stop();
                    fourth.Content = "电梯 4 " + "已到达第" + Floor + "层 ！";
                   
                    if (work != null)
                    {
                        fourthElevator.removeWork(work.getDerection(), Floor);
                        initElevator(4, Floor, work.getDerection());
                    }
                    elevatorFourthTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (fourthElevator.getDownStops().Count == 0)
                    {
                        fourthElevator.setDerection(Elevator.STOP);
                        elevatorFourthTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorFourthTimer.Start();
                    }
                    
                }
                else
                {
                    elevatorFourthTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    if (fourthElevator.getDownStops()[fourthElevator.getMax()].getDestination() <= fourthElevator.getCurrentFloor())
                    {
                        fourth.Content = "正在往下";
                        fourthElevator.setDerection(Elevator.DOWN);
                        moveFourth += 1;
                        Thickness thickness = new Thickness();
                        elevator_fourth.Content = HeightFloor[moveFourth]; //显示楼层
                        thickness.Top = moveFourth;
                        thickness.Left = vector.X;
                        elevator_fourth.Margin = thickness;
                    }
                    else
                    {
                        fourth.Content = "正在往上";
                        fourthElevator.setDerection(Elevator.UP);
                        moveFourth -= 1;
                        Thickness thickness = new Thickness();
                        elevator_fourth.Content = HeightFloor[moveFourth]; //显示楼层
                        thickness.Top = moveFourth;
                        thickness.Left = vector.X;
                        elevator_fourth.Margin = thickness;
                    }
                }
            }
            else
            {
                int Floor = HeightFloor[moveFourth];
                if (moveFourth > FloorHeight[Floor] && moveFourth < 533)
                {
                    fourth.Content = "正在往下";
                    fourthElevator.setDerection(Elevator.DOWN);
                    moveFourth += 1;
                    Thickness thickness = new Thickness();
                    elevator_fourth.Content = HeightFloor[moveFourth]; //显示楼层
                    thickness.Top = moveFourth;
                    thickness.Left = vector.X;
                    elevator_fourth.Margin = thickness;
                }
                else if (moveFourth < FloorHeight[Floor] && moveFourth > 0)
                {
                    fourth.Content = "正在往上";
                    fourthElevator.setDerection(Elevator.UP);
                    moveFourth -= 1;
                    Thickness thickness = new Thickness();
                    elevator_fourth.Content = HeightFloor[moveFourth]; //显示楼层
                    thickness.Top = moveFourth;
                    thickness.Left = vector.X;
                    elevator_fourth.Margin = thickness;
                }
                 else
                {
                    fourthElevator.setDerection(Elevator.STOP);
                    elevatorFourthTimer.Stop();
                }
            }
        }
       
        /*
        *第五个电梯的初始化
        */
        public void initElevatorFifth()
        {
            elevatorFifthTimer = new DispatcherTimer();
            elevatorFifthTimer.Interval = TimeSpan.FromSeconds(0.1);
            elevatorFifthTimer.Tick += new EventHandler(elevatorFifthTimer_Tick);
            Vector vector = VisualTreeHelper.GetOffset(elevator_fifth);
            moveFifth = (int)vector.Y;
            fifthElevator.setCurrentFloor(1);
        }
       
        /*
        *第五个电梯的运行
        */
        public void elevatorFifthTimer_Tick(object sender, EventArgs e)
        {
            Vector vector = VisualTreeHelper.GetOffset(elevator_fifth);
            moveFifth = (int)vector.Y;
            //有任务
            if (fifthElevator.getDownStops().Count != 0)
            {
                int Floor = HeightFloor[moveFifth];
                fifthElevator.setCurrentFloor(Floor);
                int Derec = fifthElevator.getDerection();
                Work work = fifthElevator.getCurrentWork(Floor);
                Work w = floorWork.getCurrrentWork(Derec, Floor);
                //达到任务层
                if (floorWork.checkStops(elevators, Derec, Floor))
                {
                    elevatorFifthTimer.Stop();   //停止
                    fifth.Content = "电梯 5 " + "已到达第" + Floor + "层 ！";
                    if (w != null)
                    initElevator(5, Floor, w.getDerection());   //初始化
                    elevatorFifthTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (fifthElevator.getDownStops().Count == 0)
                    {
                        fifthElevator.setDerection(Elevator.STOP);
                        elevatorFifthTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else
                    {
                        elevatorFifthTimer.Start();
                    }
                }
                else if (fifthElevator.isWaiting(Derec, Floor) && moveFifth + 1 == FloorHeight[Floor])
                {
                    elevatorFifthTimer.Stop();
                    fifth.Content = "电梯 5 " + "已到达第" + Floor + "层 ！" ;
                    if (work != null)
                    {
                        fifthElevator.removeWork(work.getDerection(), Floor);
                        initElevator(5, Floor, work.getDerection());
                    }
                    elevatorFifthTimer.Interval = TimeSpan.FromSeconds(longTIME);
                    if (fifthElevator.getDownStops().Count == 0)
                    {
                        fifthElevator.setDerection(Elevator.STOP);
                        elevatorFifthTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    }
                    else{
                        elevatorFifthTimer.Start();
                    }
                }
                else
                {
                    elevatorFifthTimer.Interval = TimeSpan.FromSeconds(shortTIME);
                    if (fifthElevator.getDownStops()[fifthElevator.getMax()].getDestination() <= fifthElevator.getCurrentFloor())
                    {
                        fifth.Content = "正在往下";
                        fifthElevator.setDerection(Elevator.DOWN);
                        moveFifth += 1;
                        Thickness thickness = new Thickness();
                        elevator_fifth.Content = HeightFloor[moveFifth]; //显示楼层
                        thickness.Top = moveFifth;
                        thickness.Left = vector.X;
                        elevator_fifth.Margin = thickness;
                    }
                    else
                    {
                        fifth.Content = "正在往上";
                        fifthElevator.setDerection(Elevator.UP);
                        moveFifth -= 1;
                        Thickness thickness = new Thickness();
                        elevator_fifth.Content = HeightFloor[moveFifth]; //显示楼层
                        thickness.Top = moveFifth;
                        thickness.Left = vector.X;
                        elevator_fifth.Margin = thickness;
                    }
                }
            }
            else
            {
                int Floor = HeightFloor[moveFifth];
                if (moveFifth > FloorHeight[Floor] && moveFifth < 533)
                {
                    fifth.Content = "正在往下";
                    fifthElevator.setDerection(Elevator.DOWN);
                    moveFifth += 1;
                    Thickness thickness = new Thickness();
                    elevator_fifth.Content = HeightFloor[moveFifth]; //显示楼层
                    thickness.Top = moveFifth;
                    thickness.Left = vector.X;
                    elevator_fifth.Margin = thickness;
                }
                else if (moveFifth < FloorHeight[Floor] && moveFifth > 0)
                {
                    fifth.Content = "正在往上";
                    fifthElevator.setDerection(Elevator.UP);
                    moveFifth -= 1;
                    Thickness thickness = new Thickness();
                    elevator_fifth.Content = HeightFloor[moveFifth]; //显示楼层
                    thickness.Top = moveFifth;
                    thickness.Left = vector.X;
                    elevator_fifth.Margin = thickness;
                }
                 else
                {
                    fifthElevator.setDerection(Elevator.STOP);
                    elevatorFifthTimer.Stop();
                }
            }
        }
        /*
        * 初始化
        */
        public void init()
        {
            elevators = new List<Elevator>(5);
            firstElevator = new Elevator(); //初始化
            secondElevator = new Elevator(); //初始化
            thirdElevator = new Elevator(); //初始化
            fourthElevator = new Elevator(); //初始化
            fifthElevator = new Elevator(); //初始化
            elevators.Add(firstElevator);
            elevators.Add(secondElevator);
            elevators.Add(thirdElevator);
            elevators.Add(fourthElevator);
            elevators.Add(fifthElevator);
            floorWork = new FloorWork();

            //初始化电梯楼层
            int j = 1;
            HeightFloor.Add(533, 1);
            FloorHeight.Add(1, 533);
            for (int index = 532; index >= 0; index--)
            {
                if(index % 28 == 1)
                {
                    HeightFloor.Add(index, j++);
                    FloorHeight.Add(j, index);
                }
                else
                {
                    HeightFloor.Add(index, j);
                }
            }
        }
        
        /*
        * 第一个电梯关门
        */
        private void elevator_one_close_Click(object sender, RoutedEventArgs e)
        {
            elevatorFirstTimer.Start();
        }
        /*
        * 第二个电梯关门
        */
        private void elevator_two_close_Click(object sender, RoutedEventArgs e)
        {
            elevatorSecondTimer.Start();
        }
        /*
        * 第三个电梯关门
        */
        private void elevator_three_close_Click(object sender, RoutedEventArgs e)
        {
            elevatorThirdTimer.Start();
        }
        /*
        * 第四个电梯关门
        */
        private void elevator_four_close_Click(object sender, RoutedEventArgs e)
        {
            elevatorFourthTimer.Start();
        }
        /*
        * 第五个电梯关门
        */
        private void elevator_five_close_Click(object sender, RoutedEventArgs e)
        {
            elevatorFifthTimer.Start();
        }

        /*
        * 某层响应下去
        */
        public void down(int floor, string name)
        {
            SolidColorBrush color = Brushes.Gold;
            switch (floor)
            {
                case 2:
                    elevator_one_two_down.Background = color;
                    elevator_two_two_down.Background = color;
                    elevator_three_two_down.Background = color;
                    elevator_four_two_down.Background = color;
                    elevator_five_two_down.Background = color;
                    break;
                case 3:
                    elevator_one_three_down.Background = color;
                    elevator_two_three_down.Background = color;
                    elevator_three_three_down.Background = color;
                    elevator_four_three_down.Background = color;
                    elevator_five_three_down.Background = color;
                    break;
                case 4:
                    elevator_one_four_down.Background = color;
                    elevator_two_four_down.Background = color;
                    elevator_three_four_down.Background = color;
                    elevator_four_four_down.Background = color;
                    elevator_five_four_down.Background = color;
                    break;
                case 5:
                    elevator_one_five_down.Background = color;
                    elevator_two_five_down.Background = color;
                    elevator_three_five_down.Background = color;
                    elevator_four_five_down.Background = color;
                    elevator_five_five_down.Background = color;
                    break;
                case 6:
                    elevator_one_six_down.Background = color;
                    elevator_two_six_down.Background = color;
                    elevator_three_six_down.Background = color;
                    elevator_four_six_down.Background = color;
                    elevator_five_six_down.Background = color;
                    break;
                case 7:
                    elevator_one_seven_down.Background = color;
                    elevator_two_seven_down.Background = color;
                    elevator_three_seven_down.Background = color;
                    elevator_four_seven_down.Background = color;
                    elevator_five_seven_down.Background = color;
                    break;
                case 8:
                    elevator_one_eight_down.Background = color;
                    elevator_two_eight_down.Background = color;
                    elevator_three_eight_down.Background = color;
                    elevator_four_eight_down.Background = color;
                    elevator_five_eight_down.Background = color;
                    break;
                case 9:
                    elevator_one_nine_down.Background = color;
                    elevator_two_nine_down.Background = color;
                    elevator_three_nine_down.Background = color;
                    elevator_four_nine_down.Background = color;
                    elevator_five_nine_down.Background = color;
                    break;
                case 10:
                    elevator_one_ten_down.Background = color;
                    elevator_two_ten_down.Background = color;
                    elevator_three_ten_down.Background = color;
                    elevator_four_ten_down.Background = color;
                    elevator_five_ten_down.Background = color;
                    break;
                case 11:
                    elevator_one_eleven_down.Background = color;
                    elevator_two_eleven_down.Background = color;
                    elevator_three_eleven_down.Background = color;
                    elevator_four_eleven_down.Background = color;
                    elevator_five_eleven_down.Background = color;
                    break;
                case 12:
                    elevator_one_twelve_down.Background = color;
                    elevator_two_twelve_down.Background = color;
                    elevator_three_twelve_down.Background = color;
                    elevator_four_twelve_down.Background = color;
                    elevator_five_twelve_down.Background = color;
                    break;
                case 13:
                    elevator_one_thirty_down.Background = color;
                    elevator_two_thirty_down.Background = color;
                    elevator_three_thirty_down.Background = color;
                    elevator_four_thirty_down.Background = color;
                    elevator_five_thirty_down.Background = color;
                    break;
                case 14:
                    elevator_one_forty_down.Background = color;
                    elevator_two_forty_down.Background = color;
                    elevator_three_forty_down.Background = color;
                    elevator_four_forty_down.Background = color;
                    elevator_five_forty_down.Background = color;
                    break;
                case 15:
                    elevator_one_fifty_down.Background = color;
                    elevator_two_fifty_down.Background = color;
                    elevator_three_fifty_down.Background = color;
                    elevator_four_fifty_down.Background = color;
                    elevator_five_fifty_down.Background = color;
                    break;
                case 16:
                    elevator_one_sixty_down.Background = color;
                    elevator_two_sixty_down.Background = color;
                    elevator_three_sixty_down.Background = color;
                    elevator_four_sixty_down.Background = color;
                    elevator_five_sixty_down.Background = color;
                    break;
                case 17:
                    elevator_one_seventy_down.Background = color;
                    elevator_two_seventy_down.Background = color;
                    elevator_three_seventy_down.Background = color;
                    elevator_four_seventy_down.Background = color;
                    elevator_five_seventy_down.Background = color;
                    break;
                case 18:
                    elevator_one_eighty_down.Background = color;
                    elevator_two_eighty_down.Background = color;
                    elevator_three_eighty_down.Background = color;
                    elevator_four_eighty_down.Background = color;
                    elevator_five_eighty_down.Background = color;
                    break;
                case 19:
                    elevator_one_ninty_down.Background = color;
                    elevator_two_ninty_down.Background = color;
                    elevator_three_ninty_down.Background = color;
                    elevator_four_ninty_down.Background = color;
                    elevator_five_ninty_down.Background = color;
                    break;
                case 20:
                    elevator_one_twenty_down.Background = color;
                    elevator_two_twenty_down.Background = color;
                    elevator_three_twenty_down.Background = color;
                    elevator_four_twenty_down.Background = color;
                    elevator_five_twenty_down.Background = color;
                    break;
            }
            int index = 0;
            switch (name)
            {
                case "one":
                    index = 0;
                    break;
                case "two":
                    index = 1;
                    break;
                case "three":
                    index = 2;
                    break;
                case "four":
                    index = 3;
                    break;
                case "five":
                    index = 4;
                    break;
            }

            int number = Dispatch.enterElevator(elevators, floor, Elevator.DOWN, Elevator.ENTER, index);

            switch (number)
            {
                case 0:
                    elevatorFirstTimer.Start();
                    break;
                case 1:
                    elevatorSecondTimer.Start();
                    break;
                case 2:
                    elevatorThirdTimer.Start();
                    break;
                case 3:
                    elevatorFourthTimer.Start();
                    break;
                case 4:
                    elevatorFifthTimer.Start();
                    break;
            }

        }
        /*
        * 某层响应上去
        */
        public void up(int floor, string name)
        {
            SolidColorBrush color = Brushes.Gold;
            switch (floor)
            {
                case 1:
                    elevator_one_one_up.Background = color;
                    elevator_two_one_up.Background = color;
                    elevator_three_one_up.Background = color;
                    elevator_four_one_up.Background = color;
                    elevator_five_one_up.Background = color;
                    break;
                case 2:
                    elevator_one_two_up.Background = color;
                    elevator_two_two_up.Background = color;
                    elevator_three_two_up.Background = color;
                    elevator_four_two_up.Background = color;
                    elevator_five_two_up.Background = color;
                    break;
                case 3:
                    elevator_one_three_up.Background = color;
                    elevator_two_three_up.Background = color;
                    elevator_three_three_up.Background = color;
                    elevator_four_three_up.Background = color;
                    elevator_five_three_up.Background = color;
                    break;
                case 4:
                    elevator_one_four_up.Background = color;
                    elevator_two_four_up.Background = color;
                    elevator_three_four_up.Background = color;
                    elevator_four_four_up.Background = color;
                    elevator_five_four_up.Background = color;
                    break;
                case 5:
                    elevator_one_five_up.Background = color;
                    elevator_two_five_up.Background = color;
                    elevator_three_five_up.Background = color;
                    elevator_four_five_up.Background = color;
                    elevator_five_five_up.Background = color;
                    break;
                case 6:
                    elevator_one_six_up.Background = color;
                    elevator_two_six_up.Background = color;
                    elevator_three_six_up.Background = color;
                    elevator_four_six_up.Background = color;
                    elevator_five_six_up.Background = color;
                    break;
                case 7:
                    elevator_one_seven_up.Background = color;
                    elevator_two_seven_up.Background = color;
                    elevator_three_seven_up.Background = color;
                    elevator_four_seven_up.Background = color;
                    elevator_five_seven_up.Background = color;
                    break;
                case 8:
                    elevator_one_eight_up.Background = color;
                    elevator_two_eight_up.Background = color;
                    elevator_three_eight_up.Background = color;
                    elevator_four_eight_up.Background = color;
                    elevator_five_eight_up.Background = color;
                    break;
                case 9:
                    elevator_one_nine_up.Background = color;
                    elevator_two_nine_up.Background = color;
                    elevator_three_nine_up.Background = color;
                    elevator_four_nine_up.Background = color;
                    elevator_five_nine_up.Background = color;
                    break;
                case 10:
                    elevator_one_ten_up.Background = color;
                    elevator_two_ten_up.Background = color;
                    elevator_three_ten_up.Background = color;
                    elevator_four_ten_up.Background = color;
                    elevator_five_ten_up.Background = color;
                    break;
                case 11:
                    elevator_one_eleven_up.Background = color;
                    elevator_two_eleven_up.Background = color;
                    elevator_three_eleven_up.Background = color;
                    elevator_four_eleven_up.Background = color;
                    elevator_five_eleven_up.Background = color;
                    break;
                case 12:
                    elevator_one_twelve_up.Background = color;
                    elevator_two_twelve_up.Background = color;
                    elevator_three_twelve_up.Background = color;
                    elevator_four_twelve_up.Background = color;
                    elevator_five_twelve_up.Background = color;
                    break;
                case 13:
                    elevator_one_thirty_up.Background = color;
                    elevator_two_thirty_up.Background = color;
                    elevator_three_thirty_up.Background = color;
                    elevator_four_thirty_up.Background = color;
                    elevator_five_thirty_up.Background = color;
                    break;
                case 14:
                    elevator_one_forty_up.Background = color;
                    elevator_two_forty_up.Background = color;
                    elevator_three_forty_up.Background = color;
                    elevator_four_forty_up.Background = color;
                    elevator_five_forty_up.Background = color;
                    break;
                case 15:
                    elevator_one_fifty_up.Background = color;
                    elevator_two_fifty_up.Background = color;
                    elevator_three_fifty_up.Background = color;
                    elevator_four_fifty_up.Background = color;
                    elevator_five_fifty_up.Background = color;
                    break;
                case 16:
                    elevator_one_sixty_up.Background = color;
                    elevator_two_sixty_up.Background = color;
                    elevator_three_sixty_up.Background = color;
                    elevator_four_sixty_up.Background = color;
                    elevator_five_sixty_up.Background = color;
                    break;
                case 17:
                    elevator_one_seventy_up.Background = color;
                    elevator_two_seventy_up.Background = color;
                    elevator_three_seventy_up.Background = color;
                    elevator_four_seventy_up.Background = color;
                    elevator_five_seventy_up.Background = color;
                    break;
                case 18:
                    elevator_one_eighty_up.Background = color;
                    elevator_two_eighty_up.Background = color;
                    elevator_three_eighty_up.Background = color;
                    elevator_four_eighty_up.Background = color;
                    elevator_five_eighty_up.Background = color;
                    break;
                case 19:
                    elevator_one_ninty_up.Background = color;
                    elevator_two_ninty_up.Background = color;
                    elevator_three_ninty_up.Background = color;
                    elevator_four_ninty_up.Background = color;
                    elevator_five_ninty_up.Background = color;
                    break;
               
            }

            int index = 0;
            switch (name)
            {
                case "one":
                    index = 0;
                    break;
                case "two":
                    index = 1;
                    break;
                case "three":
                    index = 2;
                    break;
                case "four":
                    index = 3;
                    break;
                case "five":
                    index = 4;
                    break;
            }
            int number = Dispatch.enterElevator(elevators, floor, Elevator.UP, Elevator.ENTER, index);
            
            switch (number)
            {
                case 0:
                    elevatorFirstTimer.Start();
                    break;
                case 1:
                    elevatorSecondTimer.Start();
                    break;
                case 2:
                    elevatorThirdTimer.Start();
                    break;
                case 3:
                    elevatorFourthTimer.Start();
                    break;
                case 4:
                    elevatorFifthTimer.Start();
                    break;
            }
            
            
        }
        //某层需要调度
        private void elevator_stop_Click(object sender, RoutedEventArgs e)
        {            
            Button btn = sender as Button;
            //Console.Write(btn.Name.Split('_')[1]);
            int height = int.Parse(btn.Tag.ToString());
            
            if (height > 0)
            {
                floorWork.addWork(height, Elevator.UP);
                up(height, btn.Name.Split('_')[1]);
            }
            else
            {
                floorWork.addWork(-height, Elevator.DOWN);
                down(-height, btn.Name.Split('_')[1]);
            }

        }
        /*
        * 电梯二选择楼层
        */
        private void elevator_two_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;    
            int floor = int.Parse(btn.Content.ToString());
            int derection = floor > secondElevator.getCurrentFloor() ? 1 : -1;
            if (secondElevator.isLegal(floor))
            {
                secondElevator.addWork(new Work(floor, derection, Elevator.OUT));
                btn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
         
        }
        /*
        * 电梯一选择楼层
        */
        private void elevator_one_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int floor= int.Parse(btn.Content.ToString());
            int derection = floor > firstElevator.getCurrentFloor() ? 1 : -1;
            if (firstElevator.isLegal(floor))
            {
                firstElevator.addWork(new Work(floor, derection, Elevator.OUT));
                btn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        /*
        * 电梯三选择楼层
        */
        private void elevator_three_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int floor = int.Parse(btn.Content.ToString());
            int derection = floor > thirdElevator.getCurrentFloor() ? 1 : -1;
            if (thirdElevator.isLegal(floor))
            {
                thirdElevator.addWork(new Work(floor, derection, Elevator.OUT));
                btn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            
           
        }
        /*
        * 电梯五选择楼层
        */
        private void elevator_five_Click(object sender, RoutedEventArgs e)
        {
          
            Button btn = sender as Button;
            int floor = int.Parse(btn.Content.ToString());
            int derection = floor > fifthElevator.getCurrentFloor() ? 1 : -1;
            if (fifthElevator.isLegal(floor))
            {
                fifthElevator.addWork(new Work(floor, derection, Elevator.OUT));
                btn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
         
           
        }
        /*
        * 电梯四选择楼层
        */
        private void elevator_four_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int floor = int.Parse(btn.Content.ToString());
            int derection = floor > fourthElevator.getCurrentFloor() ? 1 : -1;
            if (fourthElevator.isLegal(floor))
            {
                fourthElevator.addWork(new Work(floor, derection, Elevator.OUT));
                btn.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            
        }

        /*
         * 电梯一开门
         */
        private void elevator_one_open_Click(object sender, RoutedEventArgs e)
        {
            if (firstElevator.getDerection() == Elevator.STOP)
                elevatorFirstTimer.Stop();
            else MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
        }
        /*
         * 电梯二开门
         */
        private void elevator_two_open_Click(object sender, RoutedEventArgs e)
        {
            if (secondElevator.getDerection() == Elevator.STOP)
                elevatorSecondTimer.Stop();
            else MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);

        }
        /*
         * 电梯三开门
         */
        private void elevator_three_open_Click(object sender, RoutedEventArgs e)
        {
            if (thirdElevator.getDerection() == Elevator.STOP)
                elevatorThirdTimer.Stop();
            else MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
        }
        /*
         * 电梯四开门
         */
        private void elevator_four_open_Click(object sender, RoutedEventArgs e)
        {
            if (fourthElevator.getDerection() == Elevator.STOP)
                elevatorFourthTimer.Stop();
            else MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
        }
        /*
         * 电梯五开门
         */
        private void elevator_five_open_Click(object sender, RoutedEventArgs e)
        {
            if (fifthElevator.getDerection() == Elevator.STOP)
                elevatorFifthTimer.Stop();
            else MessageBox.Show("别乱按!!!!!!", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Error);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Set();
        }
    }
    /*
    * 任务，楼层和目的地
    */
    class Work
    {
        private int derection; //方向
        private int destination;  //目的楼层
        private int type;   //任务类型
        public Work()
        {
            this.derection = 0;
            this.destination = -1;
            this.type = -1;
        }
        public Work(int destination, int derection, int type)
        {
            this.derection = derection;
            this.destination = destination;
            this.type = type;
        }
        public void setType(int type)
        {
            this.type = type;
        }
        public int getType()
        {
            return type;
        }
        public int getDerection()
        {
            return derection;
        }
        public int getDestination()
        {
            return destination;
        }
        public void setDerection(int derection)
        {
            this.derection = derection;
        }
        public void setDestination(int destination)
        {
            this.destination = destination;
        }

    }
    /*
    * 楼层任务队列
    */
    class FloorWork
    {
        private Work[] upStops = new Work[20];  //电梯需要停的楼层
        private Work[] downStops = new Work[20];  //电梯需要停的楼层
        //获取当前楼层任务
        public Work getCurrrentWork(int derection, int floor)
        {
            if (derection == 1)
            {
                if (upStops[floor - 1] != null)
                {
                    return upStops[floor - 1];
                }
            }
            else
            {
                if (downStops[floor - 1] != null)
                {
                    return downStops[floor - 1];
                }
            }
           
            
            return null;
           
        }
        //添加进入任务
        public void addWork(int floor, int derection)
        {
            //往上的任务
            if(derection == Elevator.UP)
            {
                if(upStops[floor-1] == null)
                {
                    Work work = new Work(floor, derection, Elevator.ENTER);
                    upStops[floor-1] = work;
                }
                else if (upStops[floor-1].getDestination() == -1)
                {
                    Work work = new Work(floor, derection, Elevator.ENTER);
                    upStops[floor-1] = work;
                }
            }
            else
            {
                if(downStops[floor-1] == null)
                {
                    Work work = new Work(floor, derection, Elevator.ENTER);
                    downStops[floor-1] = work;
                }
                else if (downStops[floor-1].getDestination() == -1)
                {
                    Work work = new Work(floor, derection, Elevator.ENTER);
                    downStops[floor-1] = work;
                }
            }
        }
        //检查楼层是否有同方向的人等待
        public bool checkStops(List<Elevator> elevators, int derection, int height)
        {
            foreach (Elevator ele in elevators)
            {
                int floor = ele.getCurrentFloor();
                //正好有等待任务
                if(derection == 1)
                {
                    if(upStops[floor-1] != null)
                    {
                        if(upStops[floor-1].getDestination() != -1 &&ele.getDerection() == upStops[floor-1].getDerection())
                        {
                            upStops[floor-1] = new Work(); //初始化
                            foreach(Elevator elevator in elevators)
                            {
                                elevator.removeWork(ele.getDerection(), floor);
                            }
                            return true;
                        }
                    }
                }
                if(derection == -1)
                {
                    if (downStops[floor - 1] != null && height - 1 == floor)
                    {
                        if (downStops[floor - 1].getDestination() != -1 && ele.getDerection() == downStops[floor - 1].getDerection())
                        {
                            downStops[floor - 1] = new Work(); //初始化
                            foreach (Elevator elevator in elevators)
                            {
                                elevator.removeWork(ele.getDerection(), floor);
                            }
                            return true;
                        }
                    }
                }
                
                
            }
            return false;
        }
    }
    /*
    * 调度方法
    */
    class Dispatch
    {
        //进电梯
        public static int enterElevator(List<Elevator> elevators, int currentFloor, int derection, int type, int elevator)
        {
            int min = elevators[0].getWeight(currentFloor);
            int index = 0;
            bool isSameDerection = false;
            int[] isDispatch = new int[5];
            //先考虑同方向或者等待的电梯
            foreach (Elevator ele in elevators)
            {
                if ((ele.getDerection() == derection || ele.getDerection() == Elevator.STOP ) && ele.getWeight(currentFloor) <= min)
                {
                    isDispatch[index] = 1;
                    min = ele.getWeight(currentFloor);
                    isSameDerection = true;
                }
                index++;
            }
            //同方向不满足
            if (isSameDerection == false)
            {
                index = 0;
                foreach (Elevator ele in elevators)
                {
                    //再考虑反方向的电梯
                    if (ele.getWeight(currentFloor) <= min)
                    {
                        isDispatch[index] = 1;
                        min = ele.getWeight(currentFloor);
                    }
                    index++;
                }
            }
            int result = 0;
            //先选择最近的电梯
            int close = 5;
            for(int i = 0; i < 5; i++)
            {
                
                if (isDispatch[i] == 1)
                {
                    if(Math.Abs(elevator - i) < close)
                    {
                        result = i;
                        close = Math.Abs(elevator - i);
                    }
                }
            }
            
            Work work = new Work(currentFloor, derection, type);
            elevators[result].addWork(work);
            return result;
        }
    }
    /*
    * 电梯类
    */
    class Elevator
    {
        public const int UP = 1; //向上
        public const int DOWN = -1; //向下
        public const int STOP = 0; //停止

        public const int ENTER = 0; //接人
        public const int OUT = 1; //到达目的地

        private int derection = STOP;  //电梯当前运行方向
        private List<Work> downStops = new List<Work>();  //电梯需要停的楼层
        private int currentFloor = 1; //电梯当前所在楼层
        /*
        *判断输入是否合法
        */
        public bool isLegal(int floor)
        {
            bool isFindOuter = false;
            if(downStops.Count == 0 && derection != STOP)
            {
                return false;
            }
            else
            {
                foreach(Work work in downStops)
                {
                    if(work.getType() == OUT)
                    {
                        isFindOuter = true;
                    }
                }
            }
            if (!isFindOuter && derection != STOP)
                return false;
            if(derection == UP)
            {
                if(floor < currentFloor)
                {
                    return false;
                }
            }
            else if (derection == DOWN)
            {
                if (floor > currentFloor)
                {
                    return false;
                }
            }
            return true;
        }
        /*
        *返沪当前任务
        */
        public Work getCurrentWork(int floor)
        {
            if (downStops.Count != 0)
            {
                foreach (Work w in downStops)
                {
                    if (floor == w.getDestination())
                    {
                        return w;
                    }
                }
            }
            return null;
        }
        /*
        *当前任务是否
        */
        public bool isWaiting(int derection, int floor)
        {
            if (downStops.Count != 0)
            {
                foreach (Work w in downStops)
                {
                    
                    if (floor == w.getDestination())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /*
        *当前任务类型
        */
        public bool isWaitingType(int derection, int floor)
        {
            if (downStops.Count != 0)
            {
                foreach (Work w in downStops)
                {
                    if (floor == w.getDestination() && w.getType() == Elevator.ENTER)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /*
        *当前任务是否已存在
        */
        public bool isContains(Work work)
        {
            if(downStops.Count != 0)
            {
                foreach (Work w in downStops)
                {
                    if (work.getDestination() == w.getDestination() && work.getDerection() == w.getDerection() && work.getType() == w.getType())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /*
        *最小值
        */
        public int getMin()
        {
            int result = 0;
            if (downStops.Count != 0)
            {
                int index = 0;
                int min = downStops[0].getDestination();
                foreach (Work work in downStops)
                {
                    if( work.getDestination() < min)
                    {
                        min = work.getDestination();
                        result = index;
                    }
                    index++;
                }
            }
            
            return result;
        }
        /*
        *最大值
        */
        public int getMax()
        {
            int result = 0;
            if (downStops.Count != 0)
            {
                int index = 0;
                int max = downStops[0].getDestination();
                foreach (Work work in downStops)
                {
                    if (work.getDestination() > max)
                    {
                        max = work.getDestination();
                        result = index;
                    }
                    index++;
                }
            }

            return result;
        }
        /*
        *返回停止楼层
        */
        public List<Work> getDownStops()
        {
            return downStops;
        }
        /*
        *返回当前楼层
        */
        public int getCurrentFloor()
        {
            return currentFloor;
        }
        /*
        * 获取某一层相对于当前楼层的权重
        */
        public int getWeight(int Floor)
        {
            int height = 0;
            
            height = Floor - currentFloor;
            int stopNum = 0;
            if (height >= 0)
            {
                //电梯往上，需要上楼
                if (derection == UP)
                {
                    stopNum = getValue(Floor, currentFloor);
                    return stopNum * 7 + downStops.Count * 2;
                }
                //电梯正在往下
                else if (derection == DOWN)
                {
                    int min = downStops[getMin()].getDestination();
                    stopNum = downStops.Count;
              
                    return  stopNum*7 + (Floor - min)*4;
                }
                //电梯不动
                else{
                    return height* 2;
                }
            }
            else
            {
                //电梯往上
                if (derection == UP)
                {

                    int max = downStops[getMax()].getDestination();
                    stopNum = downStops.Count;
                    return stopNum * 7 + (max - Floor) * 4;  
                }
                //电梯正在往下
                else if (derection == DOWN)
                {
                    stopNum = getValue(currentFloor, Floor);
                    return stopNum * 7 + downStops.Count * 2;
                }
                //电梯不动
                else
                {
                    return -height * 2;
                }
            }
           
        }
        /*
        * 获取两个楼层之间需要停的楼层数
        */
        public int getValue(int first, int second)
        {
            int num = 0;
            foreach(Work index in downStops)
            {
                if(index.getDestination() < first && index.getDestination() > second)
                {
                    num++;
                }
            }
            return num;
        }
        /*
        * 设置当前电梯楼层
        */
        public void setCurrentFloor(int floor)
        {
            this.currentFloor = floor;
        }
        /*
        * 上电梯, 号码为number的电梯，目的楼层
        */
        public bool addWork(Work work)
        {
            if (isContains(work))
            {
                return true;
            }
            downStops.Add(work);
            this.derection = work.getDerection();
            return true;
        }
        /*
        * 下电梯, 下电梯楼层
        */
        public bool removeWork(int derection, int floor)
        {
            int index = 0;
            List<Work> works = new List<Work>();
            if (downStops.Count != 0)
            {
                foreach (Work w in downStops)
                {                  
                    if (floor == w.getDestination() && derection == w.getDerection())
                    {
                        works.Add(downStops[index]);
                        if(downStops.Count == 0)
                        {
                            break;
                        }      
                    }
                    else
                    {
                        index++;
                    }
                }
            } 
            foreach(Work work in works)
            {
                downStops.Remove(work);
            }
            return true;
        }

        /*
        * 获取当前电梯方向
        */
        public int getDerection()
        {
            return derection;
        }
        /*
        * 设置当前电梯方向
        */
        public void setDerection(int derection)
        {
            this.derection = derection;
        }
    }
}
