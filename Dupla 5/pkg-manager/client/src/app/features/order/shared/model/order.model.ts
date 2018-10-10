export class Order {
    public id: number;
    public customer: string;
    public quantity: number;
    public productId: number;
    public productName: string;
    public total: number;
}

export class OrderDeleteCommand {
    public orderIds: number[];

    constructor(orders: Order[]) {
        this.orderIds = orders.map((o: Order) => o.id);
    }
}

export class OrderCreateCommand {
    public customer: string;
    public quantity: number;
    public productId: number;

    constructor(order: Order) {
        this.customer = order.customer;
        this.quantity = order.quantity;
        this.productId = order.productId;
    }
}

export class OrderEditCommand {
    public id: number;
    public customer: string;
    public quantity: number;
    public productId: number;
    public productName: string;
    public total: number;

    constructor(order: Order) {
        this.customer = order.customer;
        this.quantity = order.quantity;
        this.productId = order.productId;
        this.productName = order.productName;
        this.total = order.total;
        this.id = order.id;
    }
}
