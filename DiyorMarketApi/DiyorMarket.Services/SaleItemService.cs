﻿using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.DTOs.SaleItem;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Services;
using DiyorMarket.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Services
{
    public class SaleItemService : ISaleItemService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        private readonly ILogger<SaleItemService> _logger;

        public SaleItemService(IMapper mapper, DiyorMarketDbContext context, ILogger<SaleItemService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<SaleItemDto> GetSaleItems()
        {
            try
            {
                var saleItems = _context.SaleItems.ToList();

                var saleItemDtos = _mapper.Map<IEnumerable<SaleItemDto>>(saleItems);

                return saleItemDtos;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between SaleItem and SaleItemDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError("Database error occured while fetching saleItems.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong while fetching saleItems.", ex.Message);
                throw;
            }
        }

        public SaleItemDto? GetSaleItemById(int id)
        {
            try
            {
                var saleItem = _context.SaleItems.FirstOrDefault(x => x.Id == id);

                var saleItemDto = _mapper.Map<SaleItemDto>(saleItem);

                return saleItemDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between SaleItem and SaleItemDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError($"Database error occured while fetching saleItem with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong while fetching saleItem with id: {id}.", ex.Message);
                throw;
            }
        }

        public SaleItemDto CreateSaleItem(SaleItemForCreateDto saleItemToCreate)
        {
            try
            {
                var saleItemEntity = _mapper.Map<SaleItem>(saleItemToCreate);

                _context.SaleItems.Add(saleItemEntity);
                _context.SaveChanges();

                var saleItemDto = _mapper.Map<SaleItemDto>(saleItemEntity);

                return saleItemDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between SaleItem and SaleItemDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError("Database error occured while creating new saleItem.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong while creating new saleItem.", ex.Message);
                throw;
            }
        }

        public void UpdateSaleItem(SaleItemForUpdateDto saleItemToUpdate)
        {
            try
            {
                var saleItemEntity = _mapper.Map<SaleItem>(saleItemToUpdate);

                _context.SaleItems.Update(saleItemEntity);
                _context.SaveChanges();
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between SaleItem and SaleItemDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError("Database error occured while updating saleItem.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong while updating saleItem.", ex.Message);
                throw;
            }
        }

        public void DeleteSaleItem(int id)
        {
            try
            {
                var saleItem = _context.SaleItems.FirstOrDefault(x => x.Id == id);
                if (saleItem is not null)
                {
                    _context.SaleItems.Remove(saleItem);
                }
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                _logger.LogError($"Database error occured while deleting saleItem with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong while deleting saleItem with id: {id}.", ex.Message);
                throw;
            }
        }
    }
}
