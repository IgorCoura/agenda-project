export class Interaction {
    id: number;
    interactionTypeId: number;
    interactionType: string;
    message: string;

    constructor(id: number, interactionTypeId: number,
        interactionType: string,
        message: string,
    ){
        this.id = id;
        this.interactionTypeId = interactionTypeId;
        this.interactionType = interactionType;
        this.message = message;
    };
}
