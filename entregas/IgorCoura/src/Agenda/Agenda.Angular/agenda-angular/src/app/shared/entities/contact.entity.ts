import { Phone } from "./phone.entity";

export interface Contact{
    id: number;
    name: string;
    phones: Phone[];
}

