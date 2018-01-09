export interface CustomerModel {
    id: number,
    name: string;
    surname: string;
    age: number;
    salary: number;
    email: string;
    address: string;
    phoneNumber: string;
    customerFavorites: any[]
}