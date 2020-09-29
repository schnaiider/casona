export class Item {
    IdProduct: number;
    IdProductType: number;
    ProductType: string;
    ProductName: string;
    Description: string;
    Price: number;
    UrlImage: string;
    IdOrder:number;
}

export class ItemTO implements Item {
    constructor(
        public IdProduct: number,
        public IdProductType: number,
        public ProductType: string,
        public ProductName: string,
        public Description: string,
        public Price: number,
        public UrlImage: string,
        public IdOrder:number
    ) { }
}