import UnintendedResult from '@/app/components/UnintendedResult'
import React from 'react'

export default function Page({ searchParams }: { searchParams: { callbackUrl: string } }) {
    return (
        <UnintendedResult
            title='You need to be logged in to do that'
            subtitle='Please click below to sign in'
            showLogin
            callbackUrl={searchParams.callbackUrl}
        />
    )
}