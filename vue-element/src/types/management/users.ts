// Create or Update User model
export interface IUserParams {
    userName: string;
    name: string;
    surname: string;
    emailAddress: string;
    isActive: boolean;
    roleNames: string[];
    password?: string; // Null when update user
    id?: number; // Has value when update user
}

// User table row model
export interface IUser {
    creationTime: Date;
    emailAddress: string;
    fullName: string;
    id: number;
    isActive: boolean;
    lastLoginTime: Date;
    name: string;
    roleNames: string[]
    surname: string;
    userName: string;
}
