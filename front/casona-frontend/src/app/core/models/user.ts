export class User {
    IdUser: number;
    IdStatus: number;
    StatusName : string;
    IdSocial: number;
    Provider : string;
    Name  : string;
    FirstName : string;
    LastName : string;
    PhotoUrl : string;
    Email : string;
    Password : string;
    CreateDate : Date;
}

export class UserTO implements User {
    constructor(
        public IdUser: 0,
        public IdStatus: 0,
        public StatusName : '',
        public IdSocial: 0,
        public Provider : '',
        public Name  : '',
        public FirstName : '',
        public LastName : '',
        public PhotoUrl : '',
        public Email : '',
        public Password : '',
        public CreateDate : Date
    ) { }
}