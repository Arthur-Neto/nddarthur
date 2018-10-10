export class Product {
    public id: number;
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: Date;
    public expiration: Date;

    public calculateProfit(): number {
        return this.sale - this.expense;
    }

    public calculateRemaningDays(): string {
        const seconds: number = 60;
        const minutes: number = 60;
        const hours: number = 24;
        const miliseconds: number = 1000;
        const remaningMiliseconds: number = this.expiration.getTime() - this.manufacture.getTime();
        const remaningDays: number = ((((remaningMiliseconds / miliseconds) / seconds) / minutes) / hours);
        if (remaningDays === 1) {
            return remaningDays + ' dia';
        } else {
            return remaningDays + ' dias';
        }
    }
}

export class ProductDeleteCommand {
    public productIds: number[];

    constructor(products: Product[]) {
        this.productIds = products.map((p: Product) => p.id);
    }
}

export class ProductEditCommand {
    public id: number;
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: string;
    public expiration: string;

    constructor(product: Product) {
        this.expiration = product.expiration.toISOString();
        this.manufacture = product.manufacture.toISOString();
        this.isAvailable = product.isAvailable;
        this.expense = product.expense;
        this.sale = product.sale;
        this.name = product.name;
        this.id = product.id;
    }
}

export class ProductCreateCommand {
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: string;
    public expiration: string;

    constructor(product: Product) {
        this.expiration = product.expiration.toISOString();
        this.manufacture = product.manufacture.toISOString();
        this.isAvailable = product.isAvailable;
        this.expense = product.expense;
        this.sale = product.sale;
        this.name = product.name;
    }
}
