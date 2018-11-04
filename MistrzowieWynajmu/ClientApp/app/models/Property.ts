export class Property {
    constructor(
        public propertyId: number,
        public type: string,
        public description: string,
        public rooms: number,
        public area: number,
        public washer: boolean,
        public iron: boolean,
        public fridge: boolean
    ) { }
}