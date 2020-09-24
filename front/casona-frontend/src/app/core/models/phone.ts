export class Phone {
    IdPhone: number;
    IdUser: number;
    IdStatus: number;
    Phone: number;
    Area: number
}

export class PhoneTO implements Phone {
    constructor(
        public IdPhone: 0,
        public IdUser: 0,
        public IdStatus: 0,
        public Phone: 0,
        public Area: 0
    ) { }
}