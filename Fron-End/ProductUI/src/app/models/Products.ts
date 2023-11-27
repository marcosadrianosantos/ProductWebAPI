import { Category } from "./Categories";

export interface Product{
    id? : string;
    name : string;
    description: string;
    price: number;
    color: string;
    categoryid: string;
    category: Category;
}