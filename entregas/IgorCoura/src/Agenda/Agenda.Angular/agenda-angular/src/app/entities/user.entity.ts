export class User{
    id: number;
    userRole: string;
    name: string;
    userName: string;
    email: string;
    userRoleId: number;
    password: string;
    confirmPassword: string;

    constructor(id: number, userRole: string, name: string, userName: string, email: string, userRoleId: number, password: string, confirmPassword: string){
        this.id = id;
        this.userRole = userRole;
        this.name = name;
        this.userName = userName;
        this.email = email;
        this.userRoleId = userRoleId;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }
}