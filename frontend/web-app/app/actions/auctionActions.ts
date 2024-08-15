'use server'

import { Auction, PagedResult } from "@/types";
import { getTokenWrapper } from "./authActions";

export async function getData(query: string): Promise<PagedResult<Auction>> {
    const res = await fetch(`http://localhost:6001/search${query}`);

    if (!res.ok) throw new Error('Failed to fetch data');

    return res.json();
}

export async function UpdateAuctionTest() {
    const data = {
        auctionEnd: new Date().toISOString(),
    }

    const token = await getTokenWrapper();

    const res = await fetch('http://localhost:6001/auctions/2c80982a-3744-4e2f-84a4-3e144b3c1e75', {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'Authorization': 'Bearer ' + token?.access_token
        },
        body: JSON.stringify(data)
    })

    if (!res.ok) return { status: res.status, message: res.statusText }

    return res.statusText;
}