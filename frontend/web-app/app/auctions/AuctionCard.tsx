import React from 'react'
import CountdownTimer from './CountdownTimer'
import { Auction } from '@/types'
import ProductImage from './ProductImage'
import Link from 'next/link'

type Props = {
    auction: Auction
}

export default function AuctionCard({ auction }: Props) {
    return (
        <Link href='#' className='group'>
            <div className='relative flex flex-col shadow-md rounded-xl overflow-hidden hover:shadow-lg hover:-translate-y-1 transition-all duration-300 max-w-sm mx-auto'>
                <ProductImage imageUrl={auction.imageUrl} />
                <div className='absolute bottom-2 left-2'>
                    <CountdownTimer auctionEnd={auction.auctionEnd} />
                </div>
            </div>
            <div className='flex flex-row justify-between mt-1 px-4 py-2 overflow-hidden max-w-sm mx-auto'>
                <h3 className='text-gray-700'>{auction.name} {auction.type}</h3>
                <p className='font-semibold text-sm'>{auction.condition}</p>
            </div>
        </Link>
    )
}