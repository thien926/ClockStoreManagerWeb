import React, { useEffect, useState } from 'react'
import  { Link } from 'react-router-dom'

function ShopPaging(props) {

    const { ShopPageReducer } = props;
    const [previous, setPrevious] = useState(null);
    const [elmsPhanTrang, setElmsPhanTrang] = useState(null);
    const [next, setNext] = useState(null);

    useEffect(() => {
        var ulrlPage = "?";
        var result = null, pageIndex = ShopPageReducer.pageIndex;
        var search = ShopPageReducer.search, sort = ShopPageReducer.sort;
        var nextPage = null, previousPage = null;

        if(search) {
            ulrlPage += "search=" + search + "&";
        }
        if(ShopPageReducer.th) {
            ulrlPage += "branchId=" +  ShopPageReducer.th.id + "&";
        }
        if(ShopPageReducer.km) {
            ulrlPage += "machineId=" +  ShopPageReducer.km.id + "&";
        }
        if(ShopPageReducer.kd) {
            ulrlPage += "wireId=" +  ShopPageReducer.kd.id + "&";
        }
        ulrlPage += "sort=" + sort + "&pageIndex=";

        if (ShopPageReducer.pageIndex) {
            var totalPage = ShopPageReducer.totalPage;
            var pageMin, pageMax;
            var range = ShopPageReducer.range, middle = totalPage / 2;
            if (totalPage <= range) {
                pageMin = 1;
                pageMax = totalPage;
            } else {
                if (pageIndex < middle) {
                    if (pageIndex > range) {
                        if (range % 2 === 0) {
                            pageMin = pageIndex - Math.floor(range / 2);
                            pageMax = pageIndex + Math.floor(range / 2);
                        }
                        else {
                            pageMin = pageIndex - Math.floor(range / 2);
                            pageMax = pageIndex + Math.floor(range / 2) + 1;
                        }
                    } else {
                        pageMin = 1;
                        pageMax = range;
                    }
                } else {
                    if (middle + range > totalPage) {
                        pageMin = totalPage - range;
                        pageMax = totalPage;
                    } else {
                        if (range % 2 === 0) {
                            pageMin = pageIndex - Math.floor(range / 2);
                            pageMax = pageIndex + Math.floor(range / 2);
                        }
                        else {
                            pageMin = pageIndex - Math.floor(range / 2);
                            pageMax = pageIndex + Math.floor(range / 2) + 1;
                        }
                    }
                }
            }
            if (pageMax > totalPage) {
                pageMax = totalPage;
                pageMin = pageMax - range + 1;
            }
            if (pageMin < pageMax - range + 1 || pageMin > pageMax - range + 1) {
                pageMin = pageMax - range + 1;
            }
            if (pageMin < 1) {
                pageMin = 1;
            }

            range = pageMax + 1 - pageMin;

            var array = new Array();
            for (let i = 0; i < range; ++i) {
                array.push(pageMin + i);
            }
            result = array.map((element, index) => {
                if (pageIndex === element) {
                    return <Link key={index} className='btn btn-info' to={`${ulrlPage}${pageIndex}`}>{element}</Link>
                }
                return <Link key={index} className='btn btn-default' to={`${ulrlPage}${element}`}>{element}</Link>
            });

            if (pageIndex !== 1) {
                previousPage = <>
                    <Link className='btn btn-default' to={`${ulrlPage}1`}><i className="fa fa-angle-double-left" aria-hidden="true" /></Link>
                    <Link className='btn btn-default' to={`${ulrlPage}${pageIndex - 1}`}><i className="fa fa-angle-left" aria-hidden="true" /></Link>
                </>
            }

            if (pageIndex !== totalPage && totalPage !== 0) {
                nextPage = <>
                    <Link className='btn btn-default' to={`${ulrlPage}${pageIndex + 1}`}><i className="fa fa-angle-right" aria-hidden="true" /></Link>
                    <Link className='btn btn-default' to={`${ulrlPage}${totalPage}`}><i className="fa fa-angle-double-right" aria-hidden="true" /></Link>

                </>;
            }

            if(totalPage === 1) {
                result = null;
            }
        }
        
        if (ShopPageReducer.listSP && ShopPageReducer.listSP.length > 0) {
            setElmsPhanTrang(result);
            if(!result) {
                setNext(null);
                setPrevious(null);
            }
            else {
                setNext(nextPage);
                setPrevious(previousPage);
            }
        }
        else {
            setElmsPhanTrang(null);
            setNext(null);
            setPrevious(null);
        }
    }, [ShopPageReducer])

    return (
        <div className="loading-more">
            {/* <Link className='btn btn-default' to='1'><i className="fa fa-angle-double-left" aria-hidden="true" /></Link>
            <Link className='btn btn-default' to='2'><i className="fa fa-angle-left" aria-hidden="true" /></Link>
            <Link className='btn btn-info' to='2'>1</Link>
            <Link className='btn btn-default' to='1'><i className="fa fa-angle-right" aria-hidden="true" /></Link>
            <Link className='btn btn-default' to='2'><i className="fa fa-angle-double-right" aria-hidden="true" /></Link> */}
            {previous}
            {elmsPhanTrang}
            {next}
        </div>
    )
}

export default ShopPaging
