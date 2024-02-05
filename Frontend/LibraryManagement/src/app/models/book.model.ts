export interface Book {
    id?: number; // Optional because it will be assigned by the server
    name: string;
    rating: number;
    author: string;
    genre: string;
    isBookAvailable: boolean;
    description: string;
    ownerId: number;
    currentlyBorrowedById?: number | null;
  }