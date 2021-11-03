using System.Collections.Generic;
using System.Xml;

namespace Hero.Pages.QuestionPageHelper
{
    public class FragenLoader
    {
        public record Frage(string Text, string OptionA, string OptionB, string OptionC, string OptionD, int korrektAntwort);

        private const string FRAGEN_PFAD = @"Data\Fragen.xml";

        private const string FRAGE_TAG = "frage";

        private const string FRAGE_TEXT_TAG = "text";

        public static FragenLoader Instanz { get; } = new FragenLoader();

        private FragenLoader() { }

        public Frage LadeXMLFragenKatalog(int fragenIndex)
        {
            XmlReaderSettings settings = new()
            {
                IgnoreWhitespace = true
            };

            using XmlReader reader = XmlReader.Create(FRAGEN_PFAD, settings);
            int aktuelleFrageIndex = 0;

            while (reader.ReadToFollowing(FRAGE_TAG))
            {
                if (aktuelleFrageIndex != fragenIndex)
                {
                    aktuelleFrageIndex++;
                    continue;
                }

                return new(
                    reader.ReadToFollowing(FRAGE_TEXT_TAG) ? reader.ReadElementContentAsString() : string.Empty,
                    reader.ReadElementContentAsString(),
                    reader.ReadElementContentAsString(),
                    reader.ReadElementContentAsString(),
                    reader.ReadElementContentAsString(),
                    reader.ReadElementContentAsInt());
            }

            return default;
        }
    }
}
