export type PagedResult<T> = {
    results: T[]
    pageCount: number
    totalCount: number
}

export type Auction = {
  reservePrice: number;
  seller: string;
  winner?: any;
  soldAmount: number;
  currentHighBid: number;
  createdAt: string;
  updatedAt: string;
  auctionEnd: string;
  status: string;
  name: string;
  description: string;
  color: string;
  imageUrl: string;
  type: string;
  brand: string;
  condition: string;
  id: string;
  }