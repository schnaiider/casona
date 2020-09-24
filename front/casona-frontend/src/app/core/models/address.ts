export class cepTO {
    cep: string
    logradouro: string
    complemento: string
    bairro: string
    localidade: string
    uf: string
    ibge: number
    gia: number
    ddd: number
    siafi: number
}


export class Commune
{
    IdCommune: number;
    IdStatus: number;
    Commune: string;
    Price: number;
    CreateDate: Date;
}

export class Address
{
    IdAddress: number;
    IdUser: number;
    IdStatus : number;
    IdCommune: number;
    Commune: string;
    CEP: number;
    Address: string;
    CreateDate: Date
}

export class AddressTO implements Address {
    constructor(
        public IdAddress: number,
        public IdUser: number,
        public IdStatus : number,
        public IdCommune: number,
        public Commune: string,
        public CEP: number,
        public Address: string,
        public CreateDate: Date
    ) { }
}
