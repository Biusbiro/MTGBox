using MTGBox.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.FormFeature
{
    public class EnumReturns
    {
        public String ToString(ECatalogTypes type)
        {
            if (type == ECatalogTypes.CardNames)
                return "card-names";
            else if (type == ECatalogTypes.ArtistNames)
                return "artist-names";
            else if (type == ECatalogTypes.WordBank)
                return "word-bank";
            else if (type == ECatalogTypes.CreatureTypes)
                return "creature-types";
            else if (type == ECatalogTypes.PlaneswalkerTypes)
                return "planeswalker-types";
            else if (type == ECatalogTypes.LandTypes)
                return "land-types";
            else if (type == ECatalogTypes.ArtifactTypes)
                return "artifact-types";
            else if (type == ECatalogTypes.EnchantmentYypes)
                return "enchantment-types";
            else if (type == ECatalogTypes.SpellTypes)
                return "spell-types";
            else if (type == ECatalogTypes.Powers)
                return "powers";
            else if (type == ECatalogTypes.Toughnesses)
                return "toughnesses";
            else if (type == ECatalogTypes.Loyalties)
                return "loyalties";
            else if (type == ECatalogTypes.Watermarks)
                return "watermarks";
            else if (type == ECatalogTypes.KeywordAbilities)
                return "keyword-abilities";
            else if (type == ECatalogTypes.KeywordActions)
                return "keyword-actions";
            else if (type == ECatalogTypes.AbilityWords)
                return "ability-words";
            else
                return String.Empty;
        }
    }
}
