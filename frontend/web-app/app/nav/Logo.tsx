'use client'

import { useParamsStore } from '@/hooks/useParamsStore'
import React from 'react'

export default function Logo() {
    const reset = useParamsStore(state => state.reset);

    return (
        <div onClick={reset} className='cursor-pointer flex items-center gap-2 text-3xl font-semibold text-red-500'>
            <img src="/blackbids-logo.png" alt="Blackbids Logo" className="h-10 w-10" />
            <div>BlackBids</div>
        </div>
    )
}