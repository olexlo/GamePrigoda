using System;
using System.Windows;
using System.Windows.Input;

namespace GamePrigoda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string origText = "Гравець стоїть перед чотирма воротами, кожне з яких веде у різний район загубленого міста.";
        public string oneText = "Щільний ліс, повний небезпеки та пригод.";
        public string twoText = "Торговий район, де можна знайти корисні речі, але можуть зустрітися ворожі торговці";
        public string threeText = "Величний замок, можливо, приховує секрети та скарби.";
        public string fourText = "Жарка пустеля, де потрібно шукати воду та засоби виживання.";
        public string step = "", gra = "";
        public bool boolSuccess = false;
        public int length = 0, randomNumber = 0, numSuccess = -1, idSuccess = 0;
        static Random random = new Random();
        static Random rdSuccess = new Random();
        public MainWindow()
        {
            InitializeComponent();
            bOne.Content = "Ліс";
            bTwo.Content = "Магазин";
            bThree.Content = "Замок";
            bFour.Content = "Пустеля";
            tZatut.Text = origText;
            tVidpov.Text = "Гра почалася";

        }

        private void bOne_MouseEnter(object sender, MouseEventArgs e)
        {
            tZatut.Text = oneText;
        }

        private void bOne_MouseLeave(object sender, MouseEventArgs e)
        {
            tZatut.Text = origText;
        }

        private void bTwo_MouseEnter(object sender, MouseEventArgs e)
        {
            tZatut.Text = twoText;
        }

        private void bTwo_MouseLeave(object sender, MouseEventArgs e)
        {
            tZatut.Text = origText;
        }

        private void bThree_MouseEnter(object sender, MouseEventArgs e)
        {
            tZatut.Text = threeText;
        }

        private void bThree_MouseLeave(object sender, MouseEventArgs e)
        {
            tZatut.Text = origText;
        }

        private void bFour_MouseEnter(object sender, MouseEventArgs e)
        {
            tZatut.Text = fourText;
        }

        private void bFour_MouseLeave(object sender, MouseEventArgs e)
        {
            tZatut.Text = origText;
        }

        private void bOne_Click(object sender, RoutedEventArgs e)
        {
            tVidpov.Text += "\n" + origText + " \n Ви обрали => " + bOne.Content;
            gra += "1";
            step = Convert.ToString(gra.Length) + gra[gra.Length-1];
            switch (Convert.ToInt32(step))
            {
                case 11:
                    // Ліс
                    bOne.Content = "вполювати здобич";
                    bTwo.Content = "нарубати дрова";
                    bThree.Content = "шукати мешканців лісу";
                    bFour.Content = "нічого не робити";
                    origText = "Залежно від вибраного, зіштовхується з різними перешкодами та може знайти корисні предмети";
                    oneText = "Ліс повний здобичи з якої можливо приготувати їжу та зробити одяг";
                    twoText = "Ліс повний деревени яку можливо застосувати для будивництва домівки та використовувати для обігріву";
                    threeText = "у лісі можуть жити люди з якими можна взаємодіяти";
                    fourText = "можна просто гуляти та дихати повітрям";
                    break;
                case 21:
                    // -- вполювати здобич -- купити прикраси -- пробратися в кімнату яку охороняють
                    numSuccess = rdSuccess.Next(0, 2);
                    if (gra == "41" && numSuccess != 0)
                    {
                        // Пустеля - Піти в бік міста, 50/50 вмерти від жажди
                        tVidpov.Text += "\n" + "\"Загиблий\": Гравець вмирає від спраги так і не дошовши до міста";
                        gra += "11";
                        oneText = "Cпробувати ще";
                        bOne.Content = "Cпробувати ще";
                        bTwo.Content = "";
                        bTwo.Visibility = Visibility.Hidden;
                        bThree.Content = "";
                        bThree.Visibility = Visibility.Hidden;
                        bFour.Content = "";
                        bFour.Visibility = Visibility.Hidden;
                        return;
                    }
                    bOne.Content = "самостійні пошуки";
                    // Ліс - Вполювати здобич - не має можливості брати допомогу 
                    if (gra == "11") 
                    {
                        bTwo.Visibility = Visibility.Hidden;
                    }
                    bTwo.Content = "допомога";
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    origText = "Після подолання перешкод, гравець натрапляє на головну проблему втекти з міста.";
                    oneText = "самостійно досліджувати та шукати виходи, бути обережним, правильно використовувати сподручні предмети";
                    twoText = "пошукати допомогу в місцевих мешканців, бути доброзичливим, запропонувати обмін";
                    threeText = "";
                    fourText = "";
                    break;
                case 31:
                    // -- запитати де вихід -- викоростати предмет
                    idSuccess = Convert.ToInt16(gra.Substring(0, 2));
                    if (idSuccess == 11 || idSuccess == 12 || idSuccess == 21 || idSuccess == 22)
                    {
                        // маємо предмет -- здобич -- дрова -- прикраси -- карта 
                        boolSuccess = true;
                    }
                    if (idSuccess == 31 || idSuccess == 23 || idSuccess == 33)
                    {
                        // 50/50 маємо предмет коли -- кімната з охороною -- обмін в крамниці -- прогулянка по замку
                        numSuccess = rdSuccess.Next(0, 2);
                        if (numSuccess != 0)
                        {
                            boolSuccess = true;
                        }
                    }
                    bOne.Visibility = Visibility.Hidden;
                    // перевирка наявність предмета
                    if (boolSuccess) 
                    {
                        bOne.Content = "спробувати використати предмет";
                        bOne.Visibility = Visibility.Visible;
                    }
                    bTwo.Visibility = Visibility.Visible;
                    bTwo.Content = "відправитись в пошуки";
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    origText = "Після подолання перешкод, гравець натрапляє на головну проблему втекти з міста.";
                    oneText = "якщо маэте предмет то після використання ви маете змогу залишити місто";
                    twoText = "якщо вам пощастить і будете наполегливим ви маете змогу залишити місто";
                    threeText = "";
                    fourText = "";
                    break;
                case 41:
                    // -- запитати де вихід -- спробувати викоростати предмет
                    bOne.Visibility = Visibility.Visible;
                    oneText = "Cпробувати ще";
                    bOne.Content = "Cпробувати ще";
                    bTwo.Content = "";
                    bTwo.Visibility = Visibility.Hidden;
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    randomNumber = random.Next(1, 5);
                    idSuccess = Convert.ToInt16(gra.Substring(0, 3));
                    switch (idSuccess)
                    {
                        case 111:
                            // ліс - здобич - викоростати
                            tVidpov.Text += "\n" + "\"Дослідник\": Гравець використовувает здобич як іжу що дае змогу та час все навколо дослідити.";
                            break;
                        case 121:
                            // ліс - дрова - викоростати
                            tVidpov.Text += "\n" + "\"Герой\": Гравець використовувает дрова щоб розпалити багаття, їого помичають та допомогають залишити ліс";
                            break;
                        case 132:
                            // ліс - пошук мешканців - запитати де вихід
                            tVidpov.Text += "\n" + "\"Герой\": Гравець знаходить у лісі людей, вони допомогають залишити ліс";
                            break;
                        case 211:
                            // магазин - прикраси - викоростати
                            tVidpov.Text += "\n" + "\"Загублений\": Гравець використовувает прикраси, всі навколо милуються гравцем, йому нема куди йти.";
                            break;
                        case 212:
                        case 222:
                        case 232:
                            // замок - (кімната з охороною, вельможа, ролгулянка замком) - запитати де вихід 
                            numSuccess = rdSuccess.Next(0, 2);
                            if (numSuccess != 0)
                            {
                                tVidpov.Text += "\n" + "\"Герой\": Гравцю підказують де вихід з міста, він долает всі перешкоди та знаходить вихід.";
                            }
                            else 
                            {
                                tVidpov.Text += "\n" + "\"Загублений\": Гравець не запам'ятал те що їому підказали, заблукал, та не знашов вихід.";
                            }
                            break;
                        case 221:
                            // магазин - карта - викоростати
                            tVidpov.Text += "\n" + "\"Герой\": Гравець використовувает карту за допомоги якої знаходить вихід з міста.";
                            break;
                        case 231:
                            // магазин - обмін - викоростати
                            numSuccess = rdSuccess.Next(0, 2);
                            if (numSuccess != 0)
                            {
                                tVidpov.Text += "\n" + "\"Герой\": Гравець використовувает предмет який дістався після обміну за допомоги якої знаходить вихід з міста.";
                            }
                            else 
                            {
                                tVidpov.Text += "\n" + "\"Загублений\": Гравець використовувает предмет який дістався після обміну, але не вдаеться покинути замок.";
                            }
                            break;

                        case 311:
                            // замок - кімната з охороною - викоростати предмет
                            tVidpov.Text += "\n" + "\"Дослідник\": Гравець використовувает гроши і охорона пускає подивитися що у кімнаті.";
                            break;
                        case 312:
                        case 322:
                            // замок - (вельможа, кімната з охороною) - запитати де вихід
                            numSuccess = rdSuccess.Next(0, 2);
                            if (numSuccess != 0)
                            {
                                tVidpov.Text += "\n" + "\"Герой\": Гравцю підказують де вихід з замку, він долает всі перешкоди та знаходить вихід.";
                            }
                            else 
                            {
                                tVidpov.Text += "\n" + "\"Дослідник\": Гравецю відмовляють в допомозі, але гравець в процесі пошуку впізнае богато цікавого про замок.";
                            }
                            break;
                        case 331:
                            // замок - прогулянка замком - викоростати предмет
                            numSuccess = rdSuccess.Next(0, 2);
                            if (numSuccess != 0)
                            {
                                tVidpov.Text += "\n" + "\"Герой\": Гравець використовувает предмет який знаходе в замку та за допомоги якого знаходить вихід.";
                            }
                            else
                            {
                                tVidpov.Text += "\n" + "\"Загублений\": Гравець не може використатися предметом, та не знаходеть вихід.";
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    // встановлюю налаштування на початкові значення 
                    origText = "Гравець стоїть перед чотирма воротами, кожне з яких веде у різний район загубленого міста.";
                    oneText = "Щільний ліс, повний небезпеки та пригод.";
                    twoText = "Торговий район, де можна знайти корисні речі, але можуть зустрітися ворожі торговці";
                    threeText = "Величний замок, можливо, приховує секрети та скарби.";
                    fourText = "Жарка пустеля, де потрібно шукати воду та засоби виживання.";
                    gra = "";
                    bOne.Content = "Ліс";
                    bTwo.Content = "Магазин";
                    bThree.Content = "Замок";
                    bFour.Content = "Пустеля";
                    tZatut.Text = origText;
                    tVidpov.Text = "Гра почалася";
                    boolSuccess = false;
                    bOne.Visibility = Visibility.Visible;
                    bTwo.Visibility = Visibility.Visible;
                    bThree.Visibility = Visibility.Visible;
                    bFour.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void bTwo_Click(object sender, RoutedEventArgs e)
        {
            tVidpov.Text += "\n" + origText + " \n Ви обрали => " + bTwo.Content;
            gra += "2";
            step = Convert.ToString(gra.Length) + gra[gra.Length - 1];
            switch (Convert.ToInt32(step))
            {
                case 12:
                    // Магазин
                    bOne.Content = "купити прикраси";
                    bTwo.Content = "купити стару карту";
                    bThree.Content = "обміняти свою річ на ,будь-яку річ с крамниці";
                    bFour.Content = "нічого не робити";
                    origText = "Залежно від вибраного, зіштовхується з різними перешкодами та може знайти корисні предмети";
                    oneText = "Прикраси можливо викоростувати, обміняти, подарувати та зачарувати";
                    twoText = "Стара карта міста, яка містить схему дорог та воріт";
                    threeText = "Можливо тобі шощастить и ти отримуешь корисну річ";
                    fourText = "можна просто гуляти по крамниці та розглядати товари";
                    break;
                case 22:
                    // -- нарубати дрова -- купити стару карту -- поговорити з вельможою -- піти в бік оазісу
                    numSuccess = rdSuccess.Next(0, 2);
                    // замок - розмова с вельможою мае можливість закінчитися загибелью гравця
                    if (gra == "32" && numSuccess == 0)
                    {
                        tVidpov.Text += "\n" + "\"Загиблий\": Гравець вмирае за гратами, розмова з вельможою була невдала";
                        gra += "11";
                        oneText = "Cпробувати ще";
                        bOne.Content = "Cпробувати ще";
                        bTwo.Content = "";
                        bTwo.Visibility = Visibility.Hidden;
                        bThree.Content = "";
                        bThree.Visibility = Visibility.Hidden;
                        bFour.Content = "";
                        bFour.Visibility = Visibility.Hidden;
                        return;
                    }
                    // Пустеля - піти в бік оазису - кінець гри (загиблий/дослідник) 
                    if (gra == "42")
                    {
                        if (numSuccess != 0)
                        {
                            tVidpov.Text += "\n" + "\"Загиблий\": Гравець вмирає від спраги так і не знайшовши оазис";
                            gra += "11";
                            oneText = "Cпробувати ще";
                            bOne.Content = "Cпробувати ще";
                            bTwo.Content = "";
                            bTwo.Visibility = Visibility.Hidden;
                            bThree.Content = "";
                            bThree.Visibility = Visibility.Hidden;
                            bFour.Content = "";
                            bFour.Visibility = Visibility.Hidden;
                            return;
                        }
                        else
                        {
                            tVidpov.Text += "\n" + "\"Дослідник\": Гравець знаходе оазис та має можливість пересуватися далі по пустелі";
                            gra += "11";
                            oneText = "Cпробувати ще";
                            bOne.Content = "Cпробувати ще";
                            bTwo.Content = "";
                            bTwo.Visibility = Visibility.Hidden;
                            bThree.Content = "";
                            bThree.Visibility = Visibility.Hidden;
                            bFour.Content = "";
                            bFour.Visibility = Visibility.Hidden;
                            return;
                        }
                    }
                    // ліс - нарубати дрова  відключаю допомогу
                    if (gra == "12")
                    {
                        bTwo.Visibility = Visibility.Hidden;
                    }
                    bOne.Content = "самостійні пошуки";
                    bTwo.Content = "допомога";
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    origText = "Після подолання перешкод, гравець натрапляє на головну проблему втекти з міста.";
                    oneText = "самостійно досліджувати та шукати виходи, бути обережним, правильно використовувати сподручні предмети";
                    twoText = "пошукати допомогу в місцевих мешканців, бути доброзичливим, запропонувати обмін";
                    threeText = "";
                    fourText = "";
                    break;
                case 32:
                    idSuccess = Convert.ToInt16(gra.Substring(0, 2));
                    // Встановлюю наявність предмету (здобич, дрова, прикраси, карта)
                    if (idSuccess == 11 || idSuccess == 12 || idSuccess == 21 || idSuccess == 22)
                    {
                        boolSuccess = true;
                    }
                    // 50/50 маємо предмет коли -- кімната з охороною -- обмін в крамниці -- прогулянка по замку
                    if (idSuccess == 31 || idSuccess == 13 || idSuccess == 23)
                    {
                        if (numSuccess != 0)
                        {
                            boolSuccess = true;
                        }
                    }
                    numSuccess = rdSuccess.Next(0, 2);
                    bOne.Content = "запитати де вихід";
                    bTwo.Visibility = Visibility.Hidden;
                    bThree.Visibility = Visibility.Hidden;
                    // вимикаемо пункт меню коли не маємо предмет
                    if (boolSuccess)
                    {
                        bTwo.Content = "запропонувати за інформацію добутий предмет";
                        bTwo.Visibility = Visibility.Visible;
                    }
                    // вимикаемо пункт меню коли не мае на кого напасти
                    if (idSuccess != 11 || idSuccess != 12 || idSuccess != 33)
                    {
                        bThree.Content = "напасти на місцевого жителя, щоб він вам розкрив таємницю";
                        bThree.Visibility = Visibility.Visible;
                    }
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    origText = "Після подолання перешкод, гравець натрапляє на головну проблему втекти з міста.";
                    oneText = "якщо бути доброзличливим та поводитись чємно то можливо хтось з місцевих жителів допоможить знайти шлях до вихіда з міста";
                    twoText = "маєте можливість обміняти предмет на інформацію яка допоможе залишити місто";
                    threeText = "використовувати грубу силу в нападі на місцевого жителя та примус його до допомоги вам у залишення міста";
                    fourText = "";
                    break;
                case 42:
                    // -- видправитись в пошуки -- запропонувати за унформацію предмет 
                    bOne.Visibility = Visibility.Visible;
                    oneText = "Cпробувати ще";
                    bOne.Content = "Cпробувати ще";
                    bTwo.Content = "";
                    bTwo.Visibility = Visibility.Hidden;
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    idSuccess = Convert.ToInt16(gra.Substring(0, 3));
                    switch (idSuccess)
                    {
                        case 111:
                        case 121:
                        case 131:
                        case 141:
                            // самостійни пошуки - видправитися в пошуки (здобич - дрова - лісні мешканці)
                            randomNumber = random.Next(1, 4);
                            switch (randomNumber)
                            {
                                case 1:
                                    tVidpov.Text += "\n" + "\"Герой\": Гравець успішно долает всі перешкоди та знаходить вихід з лісу.";
                                    break;
                                case 2:
                                    tVidpov.Text += "\n" + "\"Загублений\": Гравец заблукал у лісі та не знаходить вихід.";
                                    break;
                                case 3:
                                    tVidpov.Text += "\n" + "\"Дослідник\": Гравець знаходить цікаве місто у лісі, та зупиняеться на ньому.";
                                    break;
                            }
                            break;
                        case 132:
                            // допомога - запропонувати предмет - лісні мешканці
                            tVidpov.Text += "\n" + "\"Герой\": Гравець в обмін на предмет, отримує допомогу та вихід з лісу.";
                            break;
                        case 311:
                        case 321:
                        case 331:
                            // самостійни пошуки - видправитися в пошуки (кімната з охороною - вельможа - прогулянка замком)
                            randomNumber = random.Next(1, 4);
                            switch (randomNumber)
                            {
                                case 1:
                                    tVidpov.Text += "\n" + "\"Герой\": Гравець успішно долает всі перешкоди та знаходить вихід з замку.";
                                    break;
                                case 2:
                                    tVidpov.Text += "\n" + "\"Загублений\": Гравец заблукал у замку, та не знаходить вихід.";
                                    break;
                                case 3:
                                    tVidpov.Text += "\n" + "\"Дослідник\": Гравець знаходить цікаву кімнату у підвалі замку, та зупиняеться на ньому.";
                                    break;
                            }
                            break;
                        case 312:
                        case 322:
                            // замок - (вельможа, кімната з охороною) - запропонувати предмет
                            numSuccess = rdSuccess.Next(0, 2);
                            if (numSuccess != 0)
                            {
                                tVidpov.Text += "\n" + "\"Герой\": Гравцю підказують де вихід з замку, він долает всі перешкоди та знаходить вихід.";
                            }
                            else
                            {
                                tVidpov.Text += "\n" + "\"Дослідник\": Гравецю відмовляють в допомозі, але гравець в процесі пошуку впізнае богато цікавого про замок.";
                            }
                            break;
                        case 211:
                            // магазин - прикраси - видправитись в пошук 
                            tVidpov.Text += "\n" + "\"Дослідник\": Гравець знаходить цікави будівлі, та зупиняеться для вивчення будинків.";
                            break;
                        case 221:
                            // магазин - карта - видправитись в пошук
                            tVidpov.Text += "\n" + "\"Герой\": Гравець використовувает карту за допомоги якої знаходить вихід з міста.";
                            break;
                        case 231:
                            // магазин - обмін - видправитись в пошук 
                            numSuccess = rdSuccess.Next(0, 2);
                            if (numSuccess != 0)
                            {
                                tVidpov.Text += "\n" + "\"Герой\": Гравець використовувает предмет який дістався після обміну за допомоги якої знаходить вихід з міста.";
                            }
                            else
                            {
                                tVidpov.Text += "\n" + "\"Загублений\": Гравець використовувает предмет який дістався після обміну, але не вдаеться покинути місто.";
                            }
                            break;
                        case 212:
                        case 222:
                        case 232:
                            // магазин - (прикраси, карта, обмін) - інформація за предмет
                            tVidpov.Text += "\n" + "\"Герой\": Гравець запропонувал предмет в обмін на інформацію, їому допомогли знайти вихід з міста.";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    origText = "Гравець стоїть перед чотирма воротами, кожне з яких веде у різний район загубленого міста.";
                    oneText = "Щільний ліс, повний небезпеки та пригод.";
                    twoText = "Торговий район, де можна знайти корисні речі, але можуть зустрітися ворожі торговці";
                    threeText = "Величний замок, можливо, приховує секрети та скарби.";
                    fourText = "Жарка пустеля, де потрібно шукати воду та засоби виживання.";
                    gra = "";
                    bOne.Content = "Ліс";
                    bTwo.Content = "Магазин";
                    bThree.Content = "Замок";
                    bFour.Content = "Пустеля";
                    tZatut.Text = origText;
                    tVidpov.Text = "Гра почалася";
                    boolSuccess = false;
                    bOne.Visibility = Visibility.Visible;
                    bTwo.Visibility = Visibility.Visible;
                    bThree.Visibility = Visibility.Visible;
                    bFour.Visibility = Visibility.Visible;
                break;
            }

        }

        private void bThree_Click(object sender, RoutedEventArgs e)
        {
            tVidpov.Text += "\n" + origText + " \n Ви обрали => " + bThree.Content;
            gra += "3";
            step = Convert.ToString(gra.Length) + gra[gra.Length - 1];
            switch (Convert.ToInt32(step))
            {
                case 13:
                    // замок
                    bOne.Content = "пробратися в кімнату яку охороняють солдати";
                    bTwo.Content = "поговорити з вельможою";
                    bThree.Content = "прогулянка в замку";
                    bFour.Content = "нічого не робити";
                    origText = "Залежно від вибраного, зіштовхується з різними перешкодами та може знайти корисні предмети";
                    oneText = "В кімнате охорони можно знайти корисни предмети чі попастися на очі охороні та бути ув'язнаним";
                    twoText = "Спробовати за допомогою своей харизми добути корисну інформацію от вельможи";
                    threeText = "Можливо тобі шощастить и ти знайдеш вихід с замко чі десь заховаешся";
                    fourText = "можна просто стояти та не чого не робити";
                    break;
                case 23:
                    // -- шукати мешканців -- обмін в магазині -- прогулянка в замку 
                    if (gra.Substring(0, 2) == "43")
                    {
                        numSuccess = rdSuccess.Next(0, 2);
                        // пустеля - пошук води  50/50 кінець "загіблий" /  запропонувати знову вибрати
                        if (numSuccess != 0)
                        {
                            tVidpov.Text += "\n" + "\"Загиблий\": Гравець вмирає від спраги так і не знашовши воду";
                            gra += "11";
                            oneText = "Cпробувати ще";
                            bOne.Content = "Cпробувати ще";
                            bTwo.Content = "";
                            bTwo.Visibility = Visibility.Hidden;
                            bThree.Content = "";
                            bThree.Visibility = Visibility.Hidden;
                            bFour.Content = "";
                            bFour.Visibility = Visibility.Hidden;
                            return;
                        }
                        else 
                        {
                            tVidpov.Text += "\n" + "Гравець знаходе воду та має можливість пересуватися далі";
                            gra = "4";
                            bOne.Content = "піти в бік міста";
                            bTwo.Content = "піти в бік оазису";
                            bThree.Content = "";
                            bFour.Content = "нічого не робити";
                            origText = "Залежно від вибраного, зіштовхується з різними перешкодами та може знайти корисні предмети";
                            oneText = "Шукати щляхи яки допоможуть повернутся в місто";
                            twoText = "Їти далі у пустелю с надйею потрапити до оазису";
                            threeText = "";
                            fourText = "можна просто стояти та не чого не робити";
                            bThree.Visibility = Visibility.Hidden;
                            return;
                        }
                    }
                    // при прогуляки немає допомоги, не кого не зустріл
                    if (gra == "33")
                    {
                        bTwo.Visibility = Visibility.Hidden;
                    }
                    bOne.Content = "самостійні пошуки";
                    bTwo.Content = "допомога";
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    origText = "Після подолання перешкод, гравець натрапляє на головну проблему втекти з міста.";
                    oneText = "самостійно досліджувати та шукати виходи, бути обережним, правильно використовувати сподручні предмети";
                    twoText = "пошукати допомогу в місцевих мешканців, бути доброзичливим, запропонувати обмін";
                    threeText = "";
                    fourText = "";
                    break;
                case 43:
                    bOne.Visibility = Visibility.Visible;
                    oneText = "Cпробувати ще";
                    bOne.Content = "Cпробувати ще";
                    bTwo.Content = "";
                    bTwo.Visibility = Visibility.Hidden;
                    bThree.Content = "";
                    bThree.Visibility = Visibility.Hidden;
                    bFour.Content = "";
                    bFour.Visibility = Visibility.Hidden;
                    idSuccess = Convert.ToInt16(gra.Substring(0, 3));
                    switch (idSuccess)
                    {
                        case 132:
                            randomNumber = random.Next(1, 4);
                            // Ліс - мешканці лісу - допомога - напасти
                            switch (randomNumber)
                            {
                                case 1:
                                    tVidpov.Text += "\n" + "\"Герой\": Гравець силою примущуе лісного жителя допомогти вибратися із лісу.";
                                    break;
                                case 2:
                                    tVidpov.Text += "\n" + "\"Загублений\": Житель лісу дав відсіч гравцю і прогнав його в глиб лісу, гравец заблукал назавжди";
                                    break;
                                case 3:
                                    tVidpov.Text += "\n" + "\"Загиблий\": Місцевий житель переміг гравця, гравець гине від ран";
                                    break;
                            }
                            break;
                        case 312:
                        case 322:
                            // замок - (кімната з охороною, вельможа) - допомога - напасти
                            randomNumber = random.Next(1, 4);
                            switch (randomNumber)
                            {
                                case 1:
                                    tVidpov.Text += "\n" + "\"Герой\": Гравець більш сільніший за мешканців замку та примушує довести до виходу.";
                                    break;
                                case 2:
                                    tVidpov.Text += "\n" + "\"Загублений\": Місцевий житель більш сільніший ніж гравець та відмовляе в допомогі, гравец заблукал назавжди";
                                    break;
                                case 3:
                                    tVidpov.Text += "\n" + "\"Загиблий\": Місцевий житель перемогае гравця, і гравець поподает за грати та вмирае від хвороби";
                                    break;
                            }
                            break;
                        case 212:
                        case 222:
                        case 232:
                            // магазин - (прикраси, карта, обмін) - допомога - напасти
                            randomNumber = random.Next(1, 3);
                            switch (randomNumber)
                            {
                                case 1:
                                    tVidpov.Text += "\n" + "\"Герой\": Гравець більш сільніший за мешканців та примушує довести до виходу з міста.";
                                    break;
                                case 2:
                                    tVidpov.Text += "\n" + "\"Загиблий\": Місцевий житель перемогае гравця, і гравець поподает за грати та вмирае від хвороби";
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    origText = "Гравець стоїть перед чотирма воротами, кожне з яких веде у різний район загубленого міста.";
                    oneText = "Щільний ліс, повний небезпеки та пригод.";
                    twoText = "Торговий район, де можна знайти корисні речі, але можуть зустрітися ворожі торговці";
                    threeText = "Величний замок, можливо, приховує секрети та скарби.";
                    fourText = "Жарка пустеля, де потрібно шукати воду та засоби виживання.";
                    gra = "";
                    bOne.Content = "Ліс";
                    bTwo.Content = "Магазин";
                    bThree.Content = "Замок";
                    bFour.Content = "Пустеля";
                    tZatut.Text = origText;
                    tVidpov.Text = "Гра почалася";
                    boolSuccess = false;
                    bOne.Visibility = Visibility.Visible;
                    bTwo.Visibility = Visibility.Visible;
                    bThree.Visibility = Visibility.Visible;
                    bFour.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void bFour_Click(object sender, RoutedEventArgs e)
        {
            tVidpov.Text += "\n" + origText + " \n Ви обрали => " + bFour.Content;
            gra += "4";
            step = Convert.ToString(gra.Length) + gra[gra.Length - 1];
            switch (Convert.ToInt32(step))
            {
                case 14:
                    // Пустеля
                    bOne.Content = "піти в бік міста";
                    bTwo.Content = "піти в бік оазису";
                    bThree.Content = "спробувати роздобути воду на місці";
                    bFour.Content = "нічого не робити";
                    origText = "Залежно від вибраного, зіштовхується з різними перешкодами та може знайти корисні предмети";
                    oneText = "Шукати щляхи яки допоможуть повернутся в місто";
                    twoText = "Їти далі у пустелю с надйею потрапити до оазису";
                    threeText = "Залишитися, та пошукати воду в надіі що поручь пройде караван";
                    fourText = "можна просто стояти та не чого не робити";
                    break;
                case 24:
                    // Магазин - нечого не робити === едина можливість скористатися пунктом допомога
                    if (gra != "24")
                    {
                        bTwo.Visibility = Visibility.Hidden;
                    }
                    // коли пункт  - нечого не робити - можно вмерти :-)
                    numSuccess = rdSuccess.Next(0, 2);
                    if (numSuccess != 0 && gra.Substring(1, 1) == "4")
                    {
                        tVidpov.Text += "\n" + "\"Загиблий\": Гравець вмирае не зрозуміло від чого";
                        gra += "11";
                        oneText = "Cпробувати ще";
                        bOne.Content = "Cпробувати ще";
                        bTwo.Content = "";
                        bTwo.Visibility = Visibility.Hidden;
                        bThree.Content = "";
                        bThree.Visibility = Visibility.Hidden;
                        bFour.Content = "";
                        bFour.Visibility = Visibility.Hidden;
                        boolSuccess = false;
                        return;
                    }
                    else 
                    {
                        bOne.Content = "самостійні пошуки";
                        bTwo.Content = "допомога";
                        bThree.Content = "";
                        bThree.Visibility = Visibility.Hidden;
                        bFour.Content = "";
                        bFour.Visibility = Visibility.Hidden;
                        origText = "Після подолання перешкод, гравець натрапляє на головну проблему втекти з міста.";
                        oneText = "самостійно досліджувати та шукати виходи, бути обережним, правильно використовувати сподручні предмети";
                        twoText = "пошукати допомогу в місцевих мешканців, бути доброзичливим, запропонувати обмін";
                        threeText = "";
                        fourText = "";
                    }
                    break;
                default:
                    origText = "Гравець стоїть перед чотирма воротами, кожне з яких веде у різний район загубленого міста.";
                    oneText = "Щільний ліс, повний небезпеки та пригод.";
                    twoText = "Торговий район, де можна знайти корисні речі, але можуть зустрітися ворожі торговці";
                    threeText = "Величний замок, можливо, приховує секрети та скарби.";
                    fourText = "Жарка пустеля, де потрібно шукати воду та засоби виживання.";
                    gra = "";
                    bOne.Content = "Ліс";
                    bTwo.Content = "Магазин";
                    bThree.Content = "Замок";
                    bFour.Content = "Пустеля";
                    tZatut.Text = origText;
                    tVidpov.Text = "Гра почалася";
                    boolSuccess = false;
                    bOne.Visibility = Visibility.Visible;
                    bTwo.Visibility = Visibility.Visible;
                    bThree.Visibility = Visibility.Visible;
                    bFour.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
