using System;
using System.Linq;
using Calculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] lines =
            {
                "1.11.20, lets",
                "go",
                "1.11.20, and dont forget to go",
                "2.11.20, home now",
                "2.11.20, and come back"
            };

            Analyser analyser = new Analyser();
            var dic = analyser.Analyse(lines);

            Assert.AreEqual(dic.Keys.Count, 2);
            Assert.AreEqual(dic.Keys.ElementAt(0), "1.11.20");
            Assert.AreEqual(dic.Keys.ElementAt(1), "2.11.20");
            Assert.AreEqual(dic["1.11.20"], 2);
            Assert.AreEqual(dic["2.11.20"], 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] lines =
            {
                "1.11.20, lets",
                "go",
                "1.11.20, and dont forget to go",
                "2.11.20, home now",
            };

            Analyser analyser = new Analyser();
            var dic = analyser.Analyse(lines);

            Assert.AreEqual(dic.Keys.Count, 2);
            Assert.AreEqual(dic.Keys.ElementAt(0), "1.11.20");
            Assert.AreEqual(dic.Keys.ElementAt(1), "2.11.20");
            Assert.AreEqual(dic["1.11.20"], 2);
            Assert.AreEqual(dic["2.11.20"], 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] lines =
            {
                "1.11.20, lets",
                "go",
                "and go go",
                "1.11.20, and dont forget to go",
                "2.11.20, home now",
            };

            Analyser analyser = new Analyser();
            var dic = analyser.Analyse(lines);

            Assert.AreEqual(dic.Keys.Count, 2);
            Assert.AreEqual(dic.Keys.ElementAt(0), "1.11.20");
            Assert.AreEqual(dic.Keys.ElementAt(1), "2.11.20");
            Assert.AreEqual(dic["1.11.20"], 2);
            Assert.AreEqual(dic["2.11.20"], 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] lines =
            {
                "6/28/18, 14:28 - Meir: חזי יום טוב.אני מקווה שאני לא מפריע.אם לוחות שניות לכתחילה אז מפני מה נענשו?",
                "6/28/18, 14:30 - חזי פינקלברג: כי זה לא בסדר לעשות עגל ולעבוד לו.",
                "6/28/18, 14:31 - חזי פינקלברג: < Media omitted >",
                "6/28/18, 18:33 - Meir: כבודו, מחילה על החפירה.אבל לדעתי דבריך רק מחזקים את השאלה.כי אם הכשלון מתוכנן אז לא הייתה להם ברירה אלא לחטוא.כלומר לא הייתה להם בחירה.אם אין בחירה חופשית אין סיבה להעניש.",
                "6/28/18, 19:38 - חזי פינקלברג: שתי תשובות המכוונות לדבר אחד:",
                "1.הכול צפי והרשות נתונה אומרת המשנה באבו ץת.זה לא סתירה? כן. אבל היהודות מאמינה בשני דברים בבת אחת.",
                "2.הרב אבינר עונה לקושיה שלך כך: \"הקב\"ה רצה שזה יקרה ככה... אך לא הייתה מצווה להתנדב",
                "6/28/18, 19:39 - חזי פינקלברג: < Media omitted >",
                "6/28/18, 21:22 - Meir: ישר כוח! 👍 אהבתי את התשובה של הרב אבינר. קולעת.ושוב מחילה על בזבוז הזמן.",
                "6/28/18, 23:14 - חזי פינקלברג: אם לא תישאל אני אפגע.",
            };

            Analyser analyser = new Analyser();
            var dic = analyser.Analyse(lines);

            Assert.AreEqual(dic.Keys.Count, 1);
            Assert.AreEqual(dic.Keys.ElementAt(0), "6/28/18");
            Assert.AreEqual(dic["6/28/18"], 8);
        }
    }
}
