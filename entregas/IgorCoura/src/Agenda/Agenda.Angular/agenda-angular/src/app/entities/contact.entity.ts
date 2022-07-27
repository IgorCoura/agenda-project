import { Phone } from "./phone.entity";

export class Contact{
    id: number;
    name: string;
    phones: Phone[];
    
    constructor(id: number, name: string, phones: Phone[]){
        this.id = id;
        this.name = name;
        this.phones = phones;
    }
}

