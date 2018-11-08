export class Property {
    constructor();
    constructor(
        public id?: number,
        public type?: string,
        public description?: string,
        public rooms?: number,
        public area?: number,
        public washer?: boolean,
        public iron?: boolean,
        public fridge?: boolean,
        public addressId?: number,
        public ownerId?: number
    ) { }
}