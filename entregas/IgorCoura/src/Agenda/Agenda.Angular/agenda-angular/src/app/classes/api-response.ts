export class ApiResponse<T>{
    constructor(
        public success: boolean,
        public data: T,
        public errors: string[],
        public totalItems: number,
        ){}
    
}