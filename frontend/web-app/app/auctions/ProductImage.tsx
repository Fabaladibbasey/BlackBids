'use client'

import React, { useState } from 'react'
import Image from 'next/image'

type Props = {
    imageUrl: string
}

export default function CarImage({ imageUrl }: Props) {
    const [isLoading, setLoading] = useState(true);
    return (
        <div className='w-full h-72'>
            <Image
                src={imageUrl}
                alt='image'
                fill
                priority
                className={`
                block
                h-auto
                max-w-full
                object-contain
                py-2
                px-3
                group-hover:opacity-75
                duration-700
                ease-in-out
                ${isLoading ? 'grayscale blur-2xl scale-110' : 'grayscale-0 blur-0 scale-100'}
            `}
                onLoadingComplete={() => setLoading(false)}
            />
        </div>
    )
}