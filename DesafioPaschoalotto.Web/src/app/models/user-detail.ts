
export interface UserDetail {
    contact: Contact;
    document: Document;
    location: Location;
    id: number;
    title: string;
    name: string;
    email: string;
    birthDate: string;
    imagePath: string;
}

export interface Location {
    id: number;
    postCode: string;
    country: string;
    state: string;
    city: string;
    street: string;
    number: number;
    latitude: string;
    longitude: string;
    userId: number;
    timeZone: string;
    timeZoneOffSet: string;
}

export interface Document {
    id: number;
    type: string;
    value: string;
    userId: number;
}

export interface Contact {
    id: number;
    phone: string;
    cell: string;
    userId: number;
}