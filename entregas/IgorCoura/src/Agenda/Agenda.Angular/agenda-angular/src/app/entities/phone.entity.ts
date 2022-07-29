

export class Phone{
    id: number;
    formattedPhone: string;
    description: string;
    phoneTypeId: number;
    phoneType: string;

    constructor(id: number, formattedPhone: string, description: string, phoneTypeId: number, PhoneType: string){
        this.id = id;
        this.formattedPhone = formattedPhone;
        this.description = description;
        this.phoneTypeId = phoneTypeId;
        this.phoneType = PhoneType;
    }
}
