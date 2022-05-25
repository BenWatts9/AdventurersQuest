using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {

            int correctChallengeCount = 0;

            Console.WriteLine("What is your name, adventurer?");
            string adventurerName = Console.ReadLine();
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
1) John
2) Paul
3) George
4) Ringo
",
4, 20
            );

            Challenge forsbergAge = new Challenge("How old is Peter Forsberg", 48, 30);

            Challenge leesAge = new Challenge("How old is Lee Jennings", 30, 10);

            Challenge nathanAge = new Challenge("How old is Nathan Traczewki?", 28, 1);

            

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            List<string> colors = new List<string>();
            colors.Add("Red");
            colors.Add("Blue");
            colors.Add("Yellow");

            Robe myRobe = new Robe()
            {
                Colors = colors,
                Length = 6
            };

            Hat myHat = new Hat()
            {
                ShininessLevel = 5
            };



            Prize adventurePrize = new Prize("This is a prize");

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(adventurerName, myRobe, myHat, correctChallengeCount);


            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                forsbergAge,
                leesAge,
                nathanAge
            };


            // Loop through all the challenges and subject the Adventurer to them

            void startChallenges(){
                Console.WriteLine(theAdventurer.GetDescription());
                int count = 0;
                List<Challenge> actualChallenges = new List<Challenge>();
                while(count < 5){
                    int randNum = new Random().Next(0,8);
                    if(!(actualChallenges.Contains(challenges[randNum]))){
                        actualChallenges.Add(challenges[randNum]);
                        count++;
                       
                    }
                }
                foreach (Challenge challenge in actualChallenges)
                {
                    Console.WriteLine(theAdventurer.Awesomeness);
                    challenge.RunChallenge(theAdventurer);
                }
            }

            startChallenges();
            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }
            bool playAgain = true;
            while(playAgain)
            {
                adventurePrize.ShowPrize(theAdventurer);
                Console.WriteLine("Would you like to play agian? (Y/N)");
                string playAgainAnswer = Console.ReadLine().ToLower();
                if(playAgainAnswer == "y")
                {
                    theAdventurer.Awesomeness += theAdventurer.CorrectChallengeCount*10;
                    
                    startChallenges();
                }
                else
                {
                    Console.WriteLine("Had enough of my challenges??");
                    playAgain = false;
                }
               
              
            }
        }
    }
}