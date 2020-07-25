namespace MTGBox.Enum
{
    public enum EOrderType
    {
        name = 1, //Sort cards by name, A → Z
        set = 2, //Sort cards by their set and collector number: AAA/#1 → ZZZ/#999
        released = 3, //Sort cards by their release date: Newest → Oldest
        rarity = 4, //Sort cards by their rarity: Common → Mythic
        color = 5, //Sort cards by their color and color identity: WUBRG → multicolor → colorless
        usd = 6, //Sort cards by their lowest known U.S. Dollar price: 0.01 → highest, null last
        tix = 7, //Sort cards by their lowest known TIX price: 0.01 → highest, null last
        eur = 8, //Sort cards by their lowest known Euro price: 0.01 → highest, null last
        cmc = 9, //Sort cards by their converted mana cost: 0 → highest
        power = 10, //Sort cards by their power: null → highest
        toughness = 11, //Sort cards by their toughness: null → highest
        edhrec = 12, //Sort cards by their EDHREC ranking: lowest → highest
        artist = 13 // Sort cards by their front-side artist name: A → Z
    }
}
