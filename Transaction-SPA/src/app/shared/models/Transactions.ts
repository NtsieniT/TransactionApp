import { IType } from './Types';

export interface ITransactions {
    id: number;
    firstname: string;
    surname: string;
    email: string;
    cellPhone: string;
    amountTotal: number;
    type: string;
    typeId: number;
}