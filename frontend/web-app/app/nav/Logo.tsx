'use client'

import { useParamsStore } from '@/hooks/useParamsStore'
import { usePathname, useRouter } from 'next/navigation';
import React from 'react'

export default function Logo() {
    const router = useRouter();
    const pathname = usePathname();
    const reset = useParamsStore(state => state.reset);

    function doReset() {
        if (pathname !== '/') router.push('/');
        reset();
    }


    return (
        <div onClick={doReset} className='cursor-pointer flex items-center gap-2 text-3xl font-semibold text-red-500'>
            <img src="/blackbids-logo.png" alt="Blackbids Logo" className="h-10 w-10" />
            <div>BlackBids</div>
        </div>
    )
}