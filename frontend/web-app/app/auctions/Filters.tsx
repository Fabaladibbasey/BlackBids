import { useParamsStore } from '@/hooks/useParamsStore';
import { Button, Dropdown } from 'flowbite-react';
import React from 'react';
import { AiOutlineClockCircle, AiOutlineSortAscending } from 'react-icons/ai';
import { BsFillStopCircleFill, BsStopwatchFill } from 'react-icons/bs';
import { GiFinishLine, GiFlame } from 'react-icons/gi';

const pageSizeButtons = [4, 8, 12];

const orderButtons = [
    {
        label: 'Alphabetical',
        icon: AiOutlineSortAscending,
        value: 'brand'
    },
    {
        label: 'End date',
        icon: AiOutlineClockCircle,
        value: 'endingSoon'
    },
    {
        label: 'Recently added',
        icon: BsFillStopCircleFill,
        value: 'new'
    },
];

const filterButtons = [
    {
        label: 'Live Auctions',
        icon: GiFlame,
        value: 'live'
    },
    {
        label: 'Ending < 6 hours',
        icon: GiFinishLine,
        value: 'endingSoon'
    },
    {
        label: 'Completed',
        icon: BsStopwatchFill,
        value: 'finished'
    },
];

export default function Filters() {
    const pageSize = useParamsStore(state => state.pageSize);
    const setParams = useParamsStore(state => state.setParams);
    const orderBy = useParamsStore(state => state.orderBy);
    const filterBy = useParamsStore(state => state.filterBy);

    return (
        <div className="space-y-4 sm:space-y-0 sm:flex sm:flex-wrap sm:justify-between sm:items-center mb-8">
            {/* Filter by */}
            <div className="w-full sm:w-auto">
                <div className="sm:hidden">
                    <Dropdown label="Filter by" inline>
                        {filterButtons.map(({ label, icon: Icon, value }) => (
                            <Dropdown.Item
                                key={value}
                                onClick={() => setParams({ filterBy: value })}
                                className={`flex items-center ${filterBy === value ? 'text-red-500' : ''
                                    }`}
                            >
                                <Icon className="mr-3 h-4 w-4" />
                                {label}
                            </Dropdown.Item>
                        ))}
                    </Dropdown>
                </div>
                <div className="hidden sm:block">
                    <span className="uppercase text-sm text-gray-500 mr-2">Filter by</span>
                    <Button.Group className="flex flex-wrap">
                        {filterButtons.map(({ label, icon: Icon, value }) => (
                            <Button
                                key={value}
                                onClick={() => setParams({ filterBy: value })}
                                color={`${filterBy === value ? 'red' : 'gray'}`}
                                className="mb-2 sm:mb-0"
                            >
                                <Icon className="mr-3 h-4 w-4" />
                                {label}
                            </Button>
                        ))}
                    </Button.Group>
                </div>
            </div>

            {/* Order by */}
            <div className="w-full sm:w-auto">
                <div className="sm:hidden">
                    <Dropdown label="Order by" inline>
                        {orderButtons.map(({ label, icon: Icon, value }) => (
                            <Dropdown.Item
                                key={value}
                                onClick={() => setParams({ orderBy: value })}
                                className={`flex items-center ${orderBy === value ? 'text-red-500' : ''
                                    }`}
                            >
                                <Icon className="mr-3 h-4 w-4" />
                                {label}
                            </Dropdown.Item>
                        ))}
                    </Dropdown>
                </div>
                <div className="hidden sm:block">
                    <span className="uppercase text-sm text-gray-500 mr-2">Order by</span>
                    <Button.Group className="flex flex-wrap">
                        {orderButtons.map(({ label, icon: Icon, value }) => (
                            <Button
                                key={value}
                                onClick={() => setParams({ orderBy: value })}
                                color={`${orderBy === value ? 'red' : 'gray'}`}
                                className="mb-2 sm:mb-0"
                            >
                                <Icon className="mr-3 h-4 w-4" />
                                {label}
                            </Button>
                        ))}
                    </Button.Group>
                </div>
            </div>

            {/* Page size */}
            <div className="w-full sm:w-auto">
                <div className="sm:hidden">
                    <Dropdown label="Page size" inline>
                        {pageSizeButtons.map((value, i) => (
                            <Dropdown.Item
                                key={i}
                                onClick={() => setParams({ pageSize: value })}
                                className={`${pageSize === value ? 'text-red-500' : ''
                                    }`}
                            >
                                {value}
                            </Dropdown.Item>
                        ))}
                    </Dropdown>
                </div>
                <div className="hidden sm:block">
                    <span className="uppercase text-sm text-gray-500 mr-2">Page size</span>
                    <Button.Group className="flex flex-wrap">
                        {pageSizeButtons.map((value, i) => (
                            <Button
                                key={i}
                                onClick={() => setParams({ pageSize: value })}
                                color={`${pageSize === value ? 'red' : 'gray'}`}
                                className="mb-2 sm:mb-0"
                            >
                                {value}
                            </Button>
                        ))}
                    </Button.Group>
                </div>
            </div>
        </div>
    );
}