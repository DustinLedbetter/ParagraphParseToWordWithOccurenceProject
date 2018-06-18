/***********************************************************************************************************
 *                                          God First                                                      *
 * Created by: Dustin Ledbetter                                                                            *
 * Date: 6-15-2018                                                                                         *
 * Type: C#.NET console application                                                                        *
 * Purpose: Takes a paragraph of text and returns an array seperated into words printed out in the console * 
 * - Words are in alphabetical order and the occurence of each word in the paragraph is displayed below it *
 **********************************************************************************************************/
using System;
using System.Linq;

namespace ParagraphParseToWordWithOccurrenceProject
{
    class Program
    {

        /// <summary>
        /// Creates a string that holds the paragraph to be sorted.
        /// Splits the paragraph into words when it finds any deliminator specified.
        /// Performs actions to sort the words into a list that is in alphabetical order containing no duplicates.
        /// Gets a count of occurences for each word in the paragraph.
        /// Prints out each unique word with the occurrence count below it in alphabetical order to the console.
        /// Pauses at end til user presses a key signifying program is complete.
        /// </summary>
        static void Main()
        {

            // Creates a string that holds the paragraph to be sorted
            string paragraph = "Nyrn and Tyene may have reached King’s Landing by now, she mused, as she settled down crosslegged by the mouth of the cave to watch the falling rain.If not they ought to be there soon.Three hundred seasoned spears had gone with them, over the Boneway, past the ruins of Summerhall, and up the kingsroad. If the Lannisters had tried to spring their little trap in the kingswood, Lady Nym would have seen that it ended in disaster.Nor would the murderers have found their prey. Prince Trystane had remained safely back at Sunspear, after a tearful parting from Princess Myrcella.That accounts for one brother, thought Arianne, but where is Quentyn, if not with the griffin? Had he wed his dragon queen? King Quentyn. It still sounded silly. This new Daenerys Targaryen was younger than Arianne by half a dozen years.What would a maid that age want with her dull, bookish brother? Young girls dreamed of dashing knights with wicked smiles, not solemn boys who always did their duty.She will want Dorne, though. If she hopes to sit the Iron Throne, she must have Sunspear.If Quentyn was the price for that, this dragon queen would pay it.What if she was at Griffin’s End with Connington, and all this about another Targaryen was just some sort of subtle ruse? Her brother could well be with her.King Quentyn. Will I need to kneel to him?";

            // Splits the paragraph into words when it finds any deliminator specified
            var sortedListOfWords = paragraph.Split(new[] { ' ', ',', ':', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)

                // Converts all string array elements to lowercase
                .Select(w => w.ToLowerInvariant())

                // Sorts the words in ascending/alphabetical order
                .OrderBy(w => w)

                // Groups the same words for occurrence counting
                .GroupBy(w => w)

                // Finds the count of occurences of each word
                .Select(grp => new
                {

                    // Sets unique words with key to connect to count
                    UniqueWord = grp.Key,

                    // Sets occurrence count for each word
                    OccurrenceCount = grp.Count()

                })

                // Removes all duplicates
                .Distinct();
 
            // Cycles through the sorted list of words and prints them out to the console 
            foreach (var word in sortedListOfWords)
            {

                // Prints out each unique word with the occurrence count below it in alphabetical order to the console 
                Console.WriteLine("Unique Word: {0}" + "\n" + "Count:{1}" + "\n", word.UniqueWord, word.OccurrenceCount);

            }

            // Pauses at end til user presses a key signifying program is complete
            Console.WriteLine("\n" + "Press any key to continue...");
            Console.ReadKey();

        }



    }
} // ParagraphParseToWordWithOccurrenceProject
