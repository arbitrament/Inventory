let getIndex item source =
        let condition suspect = suspect = item 
        List.findIndex condition source

let replace old young sourceList =
    let oldIndex = getIndex old sourceList
    List.updateAt oldIndex young sourceList

type Item = 
    | Cobblestone
    | Dirt

type Cell = {Item: Item; Quantity: int}

let isCellsItemsEquals a b = a.Item = b.Item

let merge a b = 
    {a with Quantity = a.Quantity + b.Quantity}

let put inventory cell = 
    let suspectExistedCell = List.tryFind (isCellsItemsEquals cell) inventory
    
    match suspectExistedCell with
    | None -> cell :: inventory
    | Some mergableCell -> replace mergableCell (merge mergableCell cell) inventory

// Tests
let inventory = [{Item = Cobblestone; Quantity = 5}]
let inventory1 = put inventory {Item = Dirt; Quantity = 1}
let inventory2 = put inventory1 {Item = Cobblestone; Quantity = 10}
let inventory3 = put inventory2 {Item = Dirt; Quantity = 150}
printf "%A" inventory3
