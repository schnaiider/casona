export class OrderTO {
    IdOrder: number;
    IdUser: number;
    IdDelivery: number;
    
 }
 
 export class Order implements OrderTO {
     constructor(
         public IdOrder: number,
         public IdUser: number,
         public IdDelivery: number
     ) { }
 }
 
 export class OrderDetailTO
 {
     IdOrder: number;
     IdStatus: number;
     Delivery: string;
     IdOrderDetail: number;
     IdEdge: number;
     Edge: string;
     IdComposition: number;
     Composition: string;
     IdCheese: number;
     Cheese: string;
     Quantity: number;
     Price: number;
     Commentary: string;
     IdProductType: number;   
     OrderItem: OrderItemTO[];
 }
 
 export class OrderDetail implements OrderDetailTO {
     constructor(
         public IdOrder: number,
         public IdStatus: number,
         public Delivery: string,
         public IdOrderDetail: number,
         public IdEdge: number,
         public Edge: string,
         public OrderItem: OrderItemTO[],
         public IdComposition: number,
         public Composition: string,
         public IdCheese: number,
         public Cheese: string,
         public Quantity: number,
         public Price: number,
         public IdProductType: number,   
         public Commentary: string
        
     ) { }
 }
 
 export class OrderItemTO
 {
     IdOrderItem: number;
     IdOrderDetail: number;
     IdProduct: number;
     ProductName: string;
 }
 
 
 export class OrderItem implements OrderItemTO {
     constructor(
         public IdOrderItem: number,
         public IdOrderDetail: number,
         public IdProduct: number,
         public ProductName: string
     ) { }
 }
 
 
 export class OrderHistoryTO
 {
     IdHistory: number;
     IdOrder: number;
     IdStatus: number;
 }
 
 